using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.MiscCalculator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.MiscCalculator
{
    public class MiscCalculatorService : IMiscCalculatorService
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
        private readonly IGenericRepository<MiscCalculatorModel> _repository;
        #endregion

        #region ctor
        public MiscCalculatorService(IGenericRepository<MiscCalculatorModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<MiscCalculatorModel> GetMiscCalculatorDetail(long CoverPageId, Int16 LengthUnitId,Int16 PressureUnitId)
        {
            var response = new ApiResponse<MiscCalculatorModel>();
            List<MiscCalculatorModel> modelList = new List<MiscCalculatorModel>();
            try
            {
                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = (object)CoverPageId
                };
                var lengthUnitId = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = LengthUnitId
                };

                var pressureUnitId = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = PressureUnitId
                };
                modelList = _repository.ExecuteSQL<MiscCalculatorModel>("usp_smom_MiscCalculator_get", CoverPageIdParam, lengthUnitId, pressureUnitId).ToList();
                if (!(modelList.Count>0))
                {
                    modelList.Add(new MiscCalculatorModel());
                }
                response.Success = true;
                response.Data = modelList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }


        public BaseApiResponse SaveOrUpdateMiscCalculator(int UserId, long CoverPageId, Int16 LengthUnitId ,Int16 PressureUnitId, MiscCalculatorModel MiscModel)
        {
            var response = new BaseApiResponse();

            try
            {

                #region Parameters

                var MiscCalculatorIdParam = new SqlParameter
                {
                    ParameterName = "MiscCalculatorId",
                    DbType = DbType.Int64,
                    Value = (object)MiscModel.MiscCalculatorId ?? (object)DBNull.Value
                };

                var PlasticPressure_HydrualicPressureParam = new SqlParameter
                {
                    ParameterName = "PlasticPressure_HydrualicPressure",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.PlasticPressure_HydrualicPressure ?? (object)DBNull.Value
                };

                var PlasticPressure_IntensificationRatioParam = new SqlParameter
                {
                    ParameterName = "PlasticPressure_IntensificationRatio",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.PlasticPressure_IntensificationRatio ?? (object)DBNull.Value
                };
                var ScrewSurfaceSpeed_ScrewParam = new SqlParameter
                {
                    ParameterName = "ScrewSurfaceSpeed_Screw",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.ScrewSurfaceSpeed_Screw ?? (object)DBNull.Value
                };

                var ScrewSurface_RPMParam = new SqlParameter
                {
                    ParameterName = "ScrewSurface_RPM",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.ScrewSurface_RPM ?? (object)DBNull.Value
                };

                var ActualInjectionSpeed_LoadedShotParam = new SqlParameter
                {
                    ParameterName = "ActualInjectionSpeed_LoadedShot",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.ActualInjectionSpeed_LoadedShot ?? (object)DBNull.Value
                };
                var ActualInjectionSpeed_TransferParam = new SqlParameter
                {
                    ParameterName = "ActualInjectionSpeed_Transfer",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.ActualInjectionSpeed_Transfer ?? (object)DBNull.Value
                };
                var ActualInjectionSpeed_FillTimeParam = new SqlParameter
                {
                    ParameterName = "ActualInjectionSpeed_FillTime",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.ActualInjectionSpeed_FillTime ?? (object)DBNull.Value
                };

                var VolumetricInjectionSpeed_ScrewParam = new SqlParameter
                {
                    ParameterName = "VolumetricInjectionSpeed_Screw",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.VolumetricInjectionSpeed_Screw ?? (object)DBNull.Value
                };
                var VolumetricInjectionSpeed_LoadedShotSizeParam = new SqlParameter
                {
                    ParameterName = "VolumetricInjectionSpeed_LoadedShotSize",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.VolumetricInjectionSpeed_LoadedShotSize ?? (object)DBNull.Value
                };
                var VolumetricInjectionSpeed_TransferParam = new SqlParameter
                {
                    ParameterName = "VolumetricInjectionSpeed_Transfer",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.VolumetricInjectionSpeed_Transfer ?? (object)DBNull.Value
                };
                var VolumetricInjectionSpeed_FillTimeParam = new SqlParameter
                {
                    ParameterName = "VolumetricInjectionSpeed_FillTime",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.VolumetricInjectionSpeed_FillTime ?? (object)DBNull.Value
                };
                var CalculateShotSize_MaterialMeltDensityParam = new SqlParameter
                {
                    ParameterName = "CalculateShotSize_MaterialMeltDensity",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.CalculateShotSize_MaterialMeltDensity ?? (object)DBNull.Value
                };
                var CalculateShotSize_ShotWeightParam = new SqlParameter
                {
                    ParameterName = "CalculateShotSize_ShotWeight",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.CalculateShotSize_ShotWeight ?? (object)DBNull.Value
                };
                var CalculateShotSize_ScrewParam = new SqlParameter
                {
                    ParameterName = "CalculateShotSize_Screw",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.CalculateShotSize_Screw ?? (object)DBNull.Value
                };
                var CalculateShotSize_ShotSizeDecomCushionParam = new SqlParameter
                {
                    ParameterName = "CalculateShotSize_ShotSizeDecomCushion",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.CalculateShotSize_ShotSizeDecomCushion ?? (object)DBNull.Value
                };
                var ShotVolume_ShotSizeParam = new SqlParameter
                {
                    ParameterName = "ShotVolume_ShotSize",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.ShotVolume_ShotSize ?? (object)DBNull.Value
                };
                var ShotVolume_CushionParam = new SqlParameter
                {
                    ParameterName = "ShotVolume_Cushion",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.ShotVolume_Cushion ?? (object)DBNull.Value
                };
                var ShotVolumn_ScrewParam = new SqlParameter
                {
                    ParameterName = "ShotVolumn_Screw",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.ShotVolumn_Screw ?? (object)DBNull.Value
                };
                var MoldSwing_DieHeightParam = new SqlParameter
                {
                    ParameterName = "MoldSwing_DieHeight",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.MoldSwing_DieHeight ?? (object)DBNull.Value
                };
                var MoldSwing_HorizontalParam = new SqlParameter
                {
                    ParameterName = "MoldSwing_Horizontal",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.MoldSwing_Horizontal ?? (object)DBNull.Value
                };
                var MoldSwing_MaxClampOpenPositionParam = new SqlParameter
                {
                    ParameterName = "MoldSwing_MaxClampOpenPosition",
                    DbType = DbType.Double,
                    Value = (object)MiscModel.MoldSwing_MaxClampOpenPosition ?? (object)DBNull.Value
                };
                var CoverPageIdparam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = CoverPageId
                };

                var useridParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int64,
                    Value = UserId
                };
                var lengthUnitId = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = LengthUnitId
                };
                var pressureUnitId = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = PressureUnitId
                };

                var validationStatusCodeId = new SqlParameter
                {
                    ParameterName = "ValidationStatusCode",
                    DbType = DbType.Int16,
                    Value = MiscModel.ValidationStatusCode
                };

                #endregion

                var result = _repository.ExecuteSQL<long>("usp_smom_MiscCalculator_save", MiscCalculatorIdParam, PlasticPressure_HydrualicPressureParam, PlasticPressure_IntensificationRatioParam, ScrewSurfaceSpeed_ScrewParam, ScrewSurface_RPMParam, ActualInjectionSpeed_LoadedShotParam,
                   ActualInjectionSpeed_TransferParam, ActualInjectionSpeed_FillTimeParam, VolumetricInjectionSpeed_ScrewParam, VolumetricInjectionSpeed_LoadedShotSizeParam, VolumetricInjectionSpeed_TransferParam, VolumetricInjectionSpeed_FillTimeParam, CalculateShotSize_MaterialMeltDensityParam,
                  CalculateShotSize_ShotWeightParam, CalculateShotSize_ScrewParam, CalculateShotSize_ShotSizeDecomCushionParam, ShotVolume_ShotSizeParam, ShotVolume_CushionParam, ShotVolumn_ScrewParam, MoldSwing_DieHeightParam, MoldSwing_HorizontalParam, MoldSwing_MaxClampOpenPositionParam, CoverPageIdparam, useridParam, lengthUnitId, pressureUnitId, validationStatusCodeId).FirstOrDefault();
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
