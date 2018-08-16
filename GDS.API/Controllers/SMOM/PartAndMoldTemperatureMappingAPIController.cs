using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GDS.Entities.SMOM.PartAndMoldTemperatureMapping;
using GDS.Common;
using GDS.Services.SMOM.PartAndMoldTemperatureMapping;
using System.Web;
using System.IO;

namespace GDS.API.Controllers.SMOM.PartAndMoldTemperatureMapping
{
    [RoutePrefix("api")]
    public class PartAndMoldTemperatureMappingApiController : ApiController
    {
        #region Initializtions

        private readonly IPartAndMoldTemperatureMappingService _iPartAndMoldTemperatureMappingService;

        public PartAndMoldTemperatureMappingApiController()
        {
            _iPartAndMoldTemperatureMappingService = EngineContext.Resolve<IPartAndMoldTemperatureMappingService>();
        }

        #endregion

        #region Methods
        [HttpGet]
        [Route("GetPartAndMoldTemperatureMap")]
        public ApiResponse<PartAndMoldTemperatureMapModel> GetPartAndMoldTemperatureMap(int coverPageId, short lengthUnitId, bool IsDOEData = false)
        {
            return _iPartAndMoldTemperatureMappingService.GetPartAndMoldTemperatureMap(coverPageId, lengthUnitId, IsDOEData);
        }

        [HttpGet]
        [Route("GetPartAndMoldTemperature")]
        public ApiResponse<PartAndMoldTemperatureModel> GetPartAndMoldTemperature(int PartAndMoldTemperatureMapId)
        {
            return _iPartAndMoldTemperatureMappingService.GetPartAndMoldTemperature(PartAndMoldTemperatureMapId);
        }


        [HttpPost]
        [Route("AddOrUpdatePartAndMoldTemperatureMapData")]
        public BaseApiResponse AddOrUpdatePartAndMoldTemperatureMapData(int userid, short lengthUnitId, int coverPageId, PartAndMoldTemperatureMapModel PartAndMoldTemperatureMapObj)
        {
            return _iPartAndMoldTemperatureMappingService.AddOrUpdatePartAndMoldTemperatureMapData(userid, lengthUnitId, coverPageId, PartAndMoldTemperatureMapObj);
        }

        [HttpPost]
        [Route("DeletePartAndMoldTemperatureMapData")]
        public BaseApiResponse DeletePartAndMoldTemperatureMapData(int PartAndMoldTemperatureMapId)
        {
            return _iPartAndMoldTemperatureMappingService.DeletePartAndMoldTemperatureMapData(PartAndMoldTemperatureMapId);
        }

        [HttpPost]
        [Route("AddOrUpdatePartMoldTemperatureMapData")]
        public BaseApiResponse AddOrUpdatePartMoldTemperatureMapData(int LoggedInUserId, short lengthUnitId, PartAndMoldTemperatureMapModel PartAndMoldObj)
        {
            return _iPartAndMoldTemperatureMappingService.AddOrUpdatePartMoldTemperatureMapData(LoggedInUserId, lengthUnitId, PartAndMoldObj);
        }

        [HttpPost]
        [Route("UploadPartMoldTemperatureImage")]
        public BaseApiResponse UploadPartMoldTemperatureImage(string Name,string MoldNumber, bool IsDOEData = false)
        {
            var response = new BaseApiResponse();
            try
            {
                string folderPath;
                if (IsDOEData == true)
                {
                    folderPath = "DOEImages/";
                    if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "DOEImages"))
                    {
                        Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "DOEImages");
                    }
                }
                else
                {
                    folderPath = "PartMoldTempratureImages/";
                    if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "PartMoldTempratureImages"))
                    {
                        Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "PartMoldTempratureImages");
                    }
                }




                //if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "PartMoldTempratureImages"))
                //{
                //    Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "PartMoldTempratureImages");
                //}

                HttpPostedFile httpPostedFile = null;
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    httpPostedFile = HttpContext.Current.Request.Files[0];
                    httpPostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + folderPath + Name);
                    response.Message.Add("IACBI.API/" + folderPath + Name);
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(ex.Message);
            }
            return response;
        }



        #endregion
    }
}