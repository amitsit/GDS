using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.BarrelHeats;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.BarrelHeats
{
    public class BarrelHeatService : IBarrelHeatService
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
        private readonly IGenericRepository<BarrelHeatModel> _repository;

        #endregion

        #region ctor


        public BarrelHeatService(IGenericRepository<BarrelHeatModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<BarrelHeatModel> GetBerralHeatDetail(long CoverPageId,int UserId)
        {
            var response = new ApiResponse<BarrelHeatModel>();

            try
            {
                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = (object)CoverPageId
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId
                };


                var result = _repository.ExecuteSQL<BarrelHeatModel>("usp_smom_BarrelHeats_get", CoverPageIdParam, UserIdParam).ToList();
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

        public BaseApiResponse SaveOrUpdateBarrelHeats(BarrelHeatModel BarrelModel)
        {
            var response = new BaseApiResponse();
            try
            {
                #region Parameters
                var barrelheatsIdParam   = new SqlParameter { ParameterName = "BarrelHeatsId", DbType = DbType.Int64, Value = BarrelModel.BarrelHeatsId };
                var CoverPageIdParam = new SqlParameter{ParameterName = "CoverPageId", DbType = DbType.Int64,Value = (object)BarrelModel.CoverPageId ?? DBNull.Value};
                var notesParam = new SqlParameter { ParameterName = "Notes", DbType = DbType.String, Value = (object)BarrelModel.Notes ?? DBNull.Value };
                var validationStatusCodeParam = new SqlParameter { ParameterName = "ValidationStatusCode", DbType = DbType.Int16, Value = (object)BarrelModel.ValidationStatusCode ?? DBNull.Value };
                var barrelN1param = new SqlParameter { ParameterName = "BarrelN1", DbType = DbType.String, Value = (object)BarrelModel.BarrelN1 ?? DBNull.Value };
                var barrelN2param = new SqlParameter { ParameterName = "BarrelN2", DbType = DbType.String, Value = (object)BarrelModel.BarrelN2 ?? DBNull.Value };
                var barrelN3param = new SqlParameter { ParameterName = "BarrelN3", DbType = DbType.String, Value = (object)BarrelModel.BarrelN3 ?? DBNull.Value };
                var barrelN4param = new SqlParameter { ParameterName = "BarrelN4", DbType = DbType.String, Value = (object)BarrelModel.BarrelN4 ?? DBNull.Value };
                var barrel1param  = new SqlParameter { ParameterName = "Barrel1", DbType = DbType.String, Value = (object)BarrelModel.Barrel1 ?? DBNull.Value };
                var barrel2param  = new SqlParameter { ParameterName = "Barrel2", DbType = DbType.String, Value = (object)BarrelModel.Barrel2 ?? DBNull.Value };
                var barrel3param  = new SqlParameter { ParameterName = "Barrel3", DbType = DbType.String, Value = (object)BarrelModel.Barrel3 ?? DBNull.Value };
                var barrel4param  = new SqlParameter { ParameterName = "Barrel4", DbType = DbType.String, Value = (object)BarrelModel.Barrel4 ?? DBNull.Value };
                var barrel5param  = new SqlParameter { ParameterName = "Barrel5",DbType = DbType.String,Value = (object)BarrelModel.Barrel5 ?? DBNull.Value};
                var barrel6param  = new SqlParameter { ParameterName = "Barrel6", DbType = DbType.String,Value = (object)BarrelModel.Barrel6 ?? DBNull.Value};
                var barrel7param  = new SqlParameter { ParameterName = "Barrel7",DbType = DbType.String,Value = (object)BarrelModel.Barrel7 ?? DBNull.Value};
                var barrel8param  = new SqlParameter { ParameterName = "Barrel8",DbType = DbType.String,Value = (object)BarrelModel.Barrel8 ?? DBNull.Value};
                var barrel9param  = new SqlParameter { ParameterName = "Barrel9",DbType = DbType.String,Value = (object)BarrelModel.Barrel9 ?? DBNull.Value};
                var barrel10param = new SqlParameter { ParameterName = "Barrel10", DbType = DbType.String,Value = (object)BarrelModel.Barrel10 ?? DBNull.Value};
                var barrel11param = new SqlParameter { ParameterName = "Barrel11",DbType = DbType.String,Value = (object)BarrelModel.Barrel11 ?? DBNull.Value};
                var barrel12param = new SqlParameter { ParameterName = "Barrel12",DbType = DbType.String,Value = (object)BarrelModel.Barrel12 ?? DBNull.Value};
                var barrel13param = new SqlParameter { ParameterName = "Barrel13",DbType = DbType.String,Value = (object)BarrelModel.Barrel13 ?? DBNull.Value};
                var barrel14param = new SqlParameter { ParameterName = "Barrel14",DbType = DbType.String,Value = (object)BarrelModel.Barrel14 ?? DBNull.Value};
                var barrel15param = new SqlParameter { ParameterName = "Barrel15",DbType = DbType.String,Value = (object)BarrelModel.Barrel15 ?? DBNull.Value};
                var barrel16param = new SqlParameter { ParameterName = "Barrel16",DbType = DbType.String,Value = (object)BarrelModel.Barrel16 ?? DBNull.Value};
                var barrel17param = new SqlParameter { ParameterName = "Barrel17",DbType = DbType.String,Value = (object)BarrelModel.Barrel17 ?? DBNull.Value};
                var barrel18param = new SqlParameter { ParameterName = "Barrel18", DbType = DbType.String,Value = (object)BarrelModel.Barrel18 ?? DBNull.Value};
                var barrel19param = new SqlParameter { ParameterName = "Barrel19",DbType = DbType.String,Value = (object)BarrelModel.Barrel19 ?? DBNull.Value};
                var barrel20param = new SqlParameter { ParameterName = "Barrel20",DbType = DbType.String,Value = (object)BarrelModel.Barrel20 ?? DBNull.Value};
                var barrel21param = new SqlParameter { ParameterName = "Barrel21",DbType = DbType.String,Value = (object)BarrelModel.Barrel21 ?? DBNull.Value};
                var barrel22param = new SqlParameter { ParameterName = "Barrel22",DbType = DbType.String,Value = (object)BarrelModel.Barrel22 ?? DBNull.Value};
                var barrel23param = new SqlParameter { ParameterName = "Barrel23",DbType = DbType.String,Value = (object)BarrelModel.Barrel23 ?? DBNull.Value};
                var barrel24param = new SqlParameter { ParameterName = "Barrel24",DbType = DbType.String,Value = (object)BarrelModel.Barrel24 ?? DBNull.Value};
                var barrel25param = new SqlParameter { ParameterName = "Barrel25",DbType = DbType.String,Value = (object)BarrelModel.Barrel25 ?? DBNull.Value};
                var barrel26param = new SqlParameter { ParameterName = "Barrel26",DbType = DbType.String,Value = (object)BarrelModel.Barrel26 ?? DBNull.Value};
                var barrel27param = new SqlParameter { ParameterName = "Barrel27",DbType = DbType.String,Value = (object)BarrelModel.Barrel27 ?? DBNull.Value};
                var barrel28param = new SqlParameter { ParameterName = "Barrel28",DbType = DbType.String,Value = (object)BarrelModel.Barrel28 ?? DBNull.Value};
                var useridParam = new SqlParameter   { ParameterName = "UserId",  DbType = DbType.Int32,Value = (object)BarrelModel.UserId ?? DBNull.Value };
                #endregion

                var result = _repository.ExecuteSQL<long>("usp_smom_BarrelHeats_Update", barrelheatsIdParam, CoverPageIdParam, notesParam, validationStatusCodeParam, barrelN1param, barrelN2param, barrelN3param,
                    barrelN4param, barrel1param, barrel2param, barrel3param, barrel4param, barrel5param, barrel6param, barrel7param, barrel8param, barrel9param, barrel10param, barrel11param,
                    barrel12param, barrel13param, barrel14param, barrel15param, barrel16param, barrel17param, barrel18param, barrel19param, barrel20param, barrel21param,
                    barrel22param, barrel23param, barrel24param, barrel25param, barrel26param, barrel27param, barrel28param, useridParam).FirstOrDefault();
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