using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.PlasticPressureLosses;

namespace GDS.Services.SMOM.PlasticPressureLosses
{
    public class PlasticPressureLossesService : IPlasticPressureLossesService
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
        private readonly IGenericRepository<ColdRunnerSystemModel> _repository;

        #endregion

        #region ctor


        public PlasticPressureLossesService(IGenericRepository<ColdRunnerSystemModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        #region Cold Runner System

        public ApiResponse<ColdRunnerSystemModel> GetColdRunnerSystem(long coverPageId, int pressureUnitId)
        {
            var response = new ApiResponse<ColdRunnerSystemModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("CoverPageId",coverPageId),
                    new SqlParameter("PressureUnitId",pressureUnitId),
                };


                var result = _repository.ExecuteSQL<ColdRunnerSystemModel>("usp_smom_ColdRunnerSystem_GetColdRunnerSystem", paramList).ToList();
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

        public BaseApiResponse SaveColdRunnerSystem(ColdRunnerSystemModel model, int PressureUnitId)
        {
            var response = new BaseApiResponse();

            try
            {

                object[] paramList =
                {
                    new SqlParameter("CoverPageId",model.CoverPageId),
                    new SqlParameter("Hydraulic_PressureToPurgeShotThroughNozzle",model.Hydraulic_PressureToPurgeShotThroughNozzle),
                    new SqlParameter("Hydraulic_PressureToFillNozzleSprueAndRunner",model.Hydraulic_PressureToFillNozzleSprueAndRunner),
                    new SqlParameter("Hydraulic_PressureToFillNozzleSprueAndRunnerPlusGate",model.Hydraulic_PressureToFillNozzleSprueAndRunnerPlusGate),
                    new SqlParameter("Hydraulic_TotalPressureNeededToFillPart95To98PerFull",model.Hydraulic_TotalPressureNeededToFillPart95To98PerFull),
                    new SqlParameter("AllowablePressureDrop_Nozzle",model.AllowablePressureDrop_Nozzle),
                    new SqlParameter("AllowablePressureDrop_SprueAndRunner",model.AllowablePressureDrop_SprueAndRunner),
                    new SqlParameter("AllowablePressureDrop_PartGate",model.AllowablePressureDrop_PartGate),
                    new SqlParameter("AllowablePressureDrop_Part",model.AllowablePressureDrop_Part),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("PressureUnitId",PressureUnitId),
                    new SqlParameter("ValidationStatusCode",model.ValidationStatusCode)
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_ColdRunnerSystem_SaveColdRunnerSystem", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Hot Runner

        public ApiResponse<HotRunnerModel> GetHotRunner(long coverPageId, int pressureUnitId)
        {
            var response = new ApiResponse<HotRunnerModel>();

            try
            {
                object[] paramList =
               {
                    new SqlParameter("CoverPageId",coverPageId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<HotRunnerModel>("usp_smom_HotRunner_GetHotRunner", paramList).ToList();
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

        public BaseApiResponse SaveHotRunner(HotRunnerModel model, int pressureUnitId)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("CoverPageId",model.CoverPageId),
                    new SqlParameter("Hydraulic_PressureToPurgeShotThroughNozzle",model.Hydraulic_PressureToPurgeShotThroughNozzle),
                    new SqlParameter("Hydraulic_PressureToFillNozzleSprueAndRunner",model.Hydraulic_PressueToFillThroughDrops),
                    new SqlParameter("Hydraulic_TotalPressureNeededToFillPart95To98PerFull",model.Hydraulic_TotalPressureNeededToFillPart95To98PerFull),
                    new SqlParameter("AllowablePressureDrop_Nozzle",model.AllowablePressureDrop_Nozzle),
                    new SqlParameter("AllowablePressureDrop_SprueAndRunner",model.AllowablePressureDrop_Manifold),
                    new SqlParameter("AllowablePressureDrop_Part",model.AllowablePressureDrop_Part),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("PressureUnitId",pressureUnitId),
                    new SqlParameter("ValidationStatusCode",model.ValidationStatusCode)
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_HotRunner_SaveHotRunner", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Hot Drop To Cold Runner

        public ApiResponse<HotDropToColdRunner> GetHotDropToColdRunner(long coverPageId,int pressureUnitId)
        {
            var response = new ApiResponse<HotDropToColdRunner>();

            try
            {
                object[] paramList =
                  {
                    new SqlParameter("CoverPageId",coverPageId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<HotDropToColdRunner>("usp_smom_HotDropToColdRunner_GetHotDropToColdRunner", paramList).ToList();
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

        public BaseApiResponse SaveHotDropToColdRunner(HotDropToColdRunner model,int pressureUnitId)
        {
            var response = new BaseApiResponse();

            try
            {

                object[] paramList =
                {
                    new SqlParameter("CoverPageId",model.CoverPageId),
                    new SqlParameter("Hydraulic_PressureToPurgeShotThroughNozzle",model.Hydraulic_PressureToPurgeShotThroughNozzle),
                    new SqlParameter("Hydraulic_PressureToFillManifoldIntoRunners",model.Hydraulic_PressureToFillManifoldIntoRunners),
                    new SqlParameter("Hydraulic_PressureToFillManifoldPlusRunnerGatePlusPartGate",model.Hydraulic_PressureToFillManifoldPlusRunnerGatePlusPartGate),
                    new SqlParameter("Hydraulic_TotalPressureNeededToFillPart95To98PerFull",model.Hydraulic_TotalPressureNeededToFillPart95To98PerFull),
                    new SqlParameter("AllowablePressureDrop_Nozzle",model.AllowablePressureDrop_Nozzle),
                    new SqlParameter("AllowablePressureDrop_ManifoldPlusRunnerGate",model.AllowablePressureDrop_ManifoldPlusRunnerGate),
                    new SqlParameter("AllowablePressureDrop_PartGate",model.AllowablePressureDrop_PartGate),
                    new SqlParameter("AllowablePressureDrop_Part",model.AllowablePressureDrop_Part),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("PressureUnitId",pressureUnitId),
                    new SqlParameter("ValidationStatusCode",model.ValidationStatusCode)
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_HotDropToColdRunner_SaveHotDropToColdRunner", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #endregion
    }
}