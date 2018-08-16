using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.WindowsService;
using Spire.Xls;
using System.Data;
using GDS.Entities.STMP.CustomerRequirement;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using GDS.Entities.Dashboard;

namespace GDS.Services.WindowsServices
{

    public class WindowsService : IWindowsService
    {
        #region Constants

        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        private readonly IGenericRepository<WindowsServiceModel> _repository;

        #endregion

        #region ctor


        public WindowsService(IGenericRepository<WindowsServiceModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public BaseApiResponse InsertGradeCardHistoryRecord()
        {
            var response = new BaseApiResponse();

            try
            {
                var result = _repository.ExecuteSQL<int>("usp_stmp_InsertGradeCardHistory").FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<ShopLogixPlantListModel> GetAreaIdForPlantForShopLogix()
        {
            var response = new ApiResponse<ShopLogixPlantListModel>();

            try
            {
                var result = _repository.ExecuteSQL<ShopLogixPlantListModel>("usp_service_GetAreaIdForPlantForShopLogix").ToList();
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

        public BaseApiResponse UpdateOEEFromShopLogix(List<UpdateOeeInDailyRecapInputModel> listUpdateOeeInDailyRecapInputModel)
        {
            var response = new BaseApiResponse();

            try
            {
                var xmlUpdateOeeInDailyRecapInputModel = ConvertToXml<UpdateOeeInDailyRecapInputModel>.GetXMLString(listUpdateOeeInDailyRecapInputModel);

                object[] paramList =
                {
                    new SqlParameter("UpdateOeeInDailyRecapInputModelXml",xmlUpdateOeeInDailyRecapInputModel)
                };

                var result = _repository.ExecuteSQL<int>("usp_service_UpdateOEEFromShopLogix", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveQADDataFromService(List<SaveQADFromServiceInputModel> listSaveQADFromServiceInputModel)
        {
            var response = new BaseApiResponse();

            try
            {
                var successCount = 0;
                foreach (var saveQADFromServiceInputModel in listSaveQADFromServiceInputModel)
                {
                    var xmlQADData = ConvertToXml<CustomerRequirementQADInputModel>.GetXMLString(saveQADFromServiceInputModel.ListCustomerRequirementModel);

                    object[] paramList =
                    {
                        new SqlParameter("QADDataXml",xmlQADData),
                        new SqlParameter("UserId",-3),  // UserId = -3 from service user
                        new SqlParameter("FileName",saveQADFromServiceInputModel.FileInfoModel.FileName),
                        new SqlParameter("FileCreatedDate",saveQADFromServiceInputModel.FileInfoModel.FileCreatedDate),
                        new SqlParameter("FilePath",saveQADFromServiceInputModel.FileInfoModel.FilePath)
                    };

                    var result = _repository.ExecuteSQL<int>("usp_customerRequirement_insertFromFile", paramList).FirstOrDefault();
                    successCount += result > 0 ? 1 : 0;

                }

                response.Success = true;
                response.Message.Add(string.Format("{0} out of {1} files saved successfully.", successCount, listSaveQADFromServiceInputModel.Count()));

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
