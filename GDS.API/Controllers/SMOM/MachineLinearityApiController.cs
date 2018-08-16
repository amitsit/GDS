using System;
using GDS.Common;
using GDS.Entities.SMOM.MachineLinearity;
using GDS.Services.SMOM.MachineLinearity;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class MachineLinearityApiController : ApiController
    {
        #region Initializtions
        private readonly IMachineLinearityService _iMachineLinearityService;

        public MachineLinearityApiController()
        {
            _iMachineLinearityService = EngineContext.Resolve<IMachineLinearityService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetMachineConfigurationDetails")]
        public ApiResponse<MachineLinearityModel> GetMachineConfigurationDetails(int plantId, int? plantEquipmentListId, Int16 lengthUnitId, Int16 pressureUnitId,long coverPageId, bool getAllData = false)
        {
            return _iMachineLinearityService.GetMachineConfigurationDetails(plantId, plantEquipmentListId, lengthUnitId, pressureUnitId, coverPageId, getAllData);
        }

        [HttpPost]
        [Route("InsertUpdateMachineLinearity")]
        public BaseApiResponse InsertUpdateMachineLinearity(Int16 lengthUnitId, MachineLinearityModel model)
        {
            return _iMachineLinearityService.InsertUpdateMachineLinearity(lengthUnitId,model);
        }
        #endregion
    }
}
