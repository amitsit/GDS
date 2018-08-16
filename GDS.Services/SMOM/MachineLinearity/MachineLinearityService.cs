using System;
using System.Linq;
using GDS.Common;
using GDS.Entities.SMOM.MachineLinearity;
using GDS.Data.Repository;
using System.Data.SqlClient;
using System.Data;

namespace GDS.Services.SMOM.MachineLinearity
{
    class MachineLinearityService : IMachineLinearityService
    {
        #region Constants
        /// <summary>
        /// Declare The logger object for perform operation on Logger
        /// </summary>
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Fields
        /// <summary>
        /// Declare The provider repository object for perform operation on Provider repository
        /// </summary>
        private readonly IGenericRepository<MachineLinearityModel> _repository;
        #endregion

        #region ctor
        public MachineLinearityService(IGenericRepository<MachineLinearityModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<MachineLinearityModel> GetMachineConfigurationDetails(int plantId, int? plantEquipmentListId, Int16 lengthUnitId, Int16 pressureUnitId, long coverPageId, bool getAllData = false)
        {
            var response = new ApiResponse<MachineLinearityModel>();
            try
            {
                var PlantId = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = plantId
                };
                var PlantEquipmentListId = new SqlParameter
                {
                    ParameterName = "PlantEquipmentListId",
                    DbType = DbType.Int32,
                    Value = plantEquipmentListId
                };
                var LengthUnitId = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = lengthUnitId
                };
                var PressureUnitId = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = pressureUnitId
                };
                var result = _repository.ExecuteSQL<MachineLinearityModel>("usp_smom_MachineLinearityConfiguration_get", PlantId, PlantEquipmentListId, LengthUnitId, PressureUnitId).ToList();
                if (result.Any() && getAllData)
                {
                    MachineLinearityModel objMachineLinearityModel = result.FirstOrDefault();
                    GetMachineLinearityPositionSetting(objMachineLinearityModel, plantId, plantEquipmentListId, lengthUnitId, coverPageId);

                    long machineLinearityPositionSettingId = 0;
                    if (objMachineLinearityModel.PositionSettingDetails != null && objMachineLinearityModel.PositionSettingDetails.MachineLinearityPositionSettingId > 0)
                    {
                        machineLinearityPositionSettingId = objMachineLinearityModel.PositionSettingDetails.MachineLinearityPositionSettingId;
                    }

                    if (objMachineLinearityModel?.MaxInjectionSpeed == null)
                    {
                        objMachineLinearityModel.MaxInjectionSpeed = 0;
                    }

                    GetMachineShotWithParts(objMachineLinearityModel, machineLinearityPositionSettingId);
                    GetMachineLinearityAirShot(objMachineLinearityModel, machineLinearityPositionSettingId);

                    if (objMachineLinearityModel.PositionSettingDetails == null)
                    {
                        objMachineLinearityModel.PositionSettingDetails = new MachineLinearityPositionSetting();
                    }
                }
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }

        private void GetMachineLinearityPositionSetting(MachineLinearityModel obj, int plantId, int? plantEquipmentListId, Int16 lengthUnitId, long coverPageId)
        {
            var PlantId = new SqlParameter
            {
                ParameterName = "PlantId",
                DbType = DbType.Int32,
                Value = plantId
            };
            var PlantEquipmentListId = new SqlParameter
            {
                ParameterName = "PlantEquipmentListId",
                DbType = DbType.Int32,
                Value = plantEquipmentListId
            };
            var CoverPageId = new SqlParameter
            {
                ParameterName = "CoverPageId",
                DbType = DbType.Int64,
                Value = coverPageId
            };
            var LengthUnitId = new SqlParameter
            {
                ParameterName = "LengthUnitId",
                DbType = DbType.Int16,
                Value = lengthUnitId
            };

            obj.PositionSettingDetails = _repository.ExecuteSQL<MachineLinearityPositionSetting>("usp_smom_MachineLinearityPositionSetting_get", PlantId, PlantEquipmentListId, CoverPageId, LengthUnitId).ToList().FirstOrDefault();
        }

        private void GetMachineShotWithParts(MachineLinearityModel obj, long machineLinearityPositionSettingId)
        {
            var MaxInjectionSpeed = new SqlParameter
            {
                ParameterName = "MaxInjectionSpeed",
                DbType = DbType.Double,
                Value = obj.MaxInjectionSpeed
            };
            var MachineLinearityPositionSettingId = new SqlParameter
            {
                ParameterName = "MachineLinearityPositionSettingId",
                DbType = DbType.Int64,
                Value = machineLinearityPositionSettingId
            };

            obj.ShotWithPartsList = _repository.ExecuteSQL<MachineLinearityShotWithParts>("usp_smom_MachineLinearityShotWithPart_get", MaxInjectionSpeed, MachineLinearityPositionSettingId).ToList();
        }

        private void GetMachineLinearityAirShot(MachineLinearityModel obj, long machineLinearityPositionSettingId)
        {
            var MaxInjectionSpeed = new SqlParameter
            {
                ParameterName = "MaxInjectionSpeed",
                DbType = DbType.Double,
                Value = obj.MaxInjectionSpeed
            };
            var MachineLinearityPositionSettingId = new SqlParameter
            {
                ParameterName = "MachineLinearityPositionSettingId",
                DbType = DbType.Int64,
                Value = machineLinearityPositionSettingId
            };
            obj.AirShotList = _repository.ExecuteSQL<MachineLinearityAirShot>("usp_smom_MachineLinearityAirShot_get", MaxInjectionSpeed, MachineLinearityPositionSettingId).ToList();
        }

        public BaseApiResponse InsertUpdateMachineLinearity(Int16 lengthUnitId, MachineLinearityModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                DataTable dtShotWithParts = Converter.ToDataTable(model.ShotWithPartsList);
                DataTable dtAirShot = Converter.ToDataTable(model.AirShotList);

                object[] paramList =
                 {
                    new SqlParameter("MachineLinearityPositionSettingId",model.PositionSettingDetails.MachineLinearityPositionSettingId)
                  // ,new SqlParameter("PlantId",model.PlantId)
                   //,new SqlParameter("PlantEquipmentListId",model.PlantEquipmentListId)
                   ,new SqlParameter("CoverPageId",model.CoverPageId)
                   ,new SqlParameter("MaterialId",(object)model.PositionSettingDetails.MaterialId?? DBNull.Value)
                   ,new SqlParameter("ShotSize",(object)model.PositionSettingDetails.ShotSize?? DBNull.Value)
                   ,new SqlParameter("Decompress",(object)model.PositionSettingDetails.Decompress?? DBNull.Value)
                   ,new SqlParameter("Transfer",(object)model.PositionSettingDetails.Transfer?? DBNull.Value)
                   ,new SqlParameter("Nozzle",(object)model.PositionSettingDetails.Nozzle?? DBNull.Value)
                   ,new SqlParameter("Valve",(object)model.PositionSettingDetails.Valve?? DBNull.Value)
                   ,new SqlParameter("FrontZone",(object)model.PositionSettingDetails.FrontZone?? DBNull.Value)
                   ,new SqlParameter("MidFront",(object)model.PositionSettingDetails.MidFront?? DBNull.Value)
                   ,new SqlParameter("MidRear",(object)model.PositionSettingDetails.MidRear?? DBNull.Value)
                   ,new SqlParameter("RearZone",(object)model.PositionSettingDetails.RearZone?? DBNull.Value)
                   ,new SqlParameter("LoggedInUserId",model.LoggedInUserId)
                    ,new SqlParameter("LengthUnitId",lengthUnitId)
                   ,new SqlParameter
                   {
                       ParameterName = "ShotWithPartsList",
                       SqlDbType = SqlDbType.Structured,
                       TypeName = "dbo.ut_MachineLinearityShotWithPartsList",
                       Value = dtShotWithParts
                   }
                    ,new SqlParameter
                    {
                        ParameterName = "AirShotList",
                        SqlDbType = SqlDbType.Structured,
                        TypeName = "dbo.ut_MachineLinearityAirShotList",
                        Value = dtAirShot
                    }
                };

                var result = _repository.ExecuteSQL<Int64>("usp_smom_MachineLinearity_insert_update", paramList).FirstOrDefault();
                response.Success = result > 0;
                response.lng_InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion
    }
}
