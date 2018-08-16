using GDS.Common;
using GDS.Entities.SMOM.WaterFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.WaterFlow
{
    public interface IWaterFlowService
    {
        ApiResponse<WaterFlowMasterModel> GetWaterFlowDetail(int CoverPageId, Int16 LengthUnitId, Int16 PressureUnitId);
        ApiResponse<WaterMinuteDataModel> GetWaterFlowMinuteDataDetail(int WaterFlowId, Int16 LengthUnitId, Int16 PressureUnitId);
        BaseApiResponse SaveWaterFlowDetail(WaterFlowMasterModel model, int CreatedBy, Int16 LengthUnitId, Int16 PressureUnitId, byte? validationStatusCode);
        BaseApiResponse SaveGallonMappingList(int UserId, WaterflowGallonMappingModel gallonMappingList);
        ApiResponse<WaterflowGallonMappingModel> GetGallonMappingList(int WaterFlowId);
        ApiResponse<WaterFlowThermolatorDiameterMappingModel> GetWaterFlowThermolatorMappingDetail(int WaterFlowId, Int16 LengthUnitId, Int16 PressureUnitId);
    }
}
