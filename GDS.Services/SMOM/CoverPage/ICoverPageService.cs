using GDS.Common;
using GDS.Entities.SMOM.CoverPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.CoverPage
{
    public interface ICoverPageService
    {
        ApiResponse<CoverPageModel> GetCoverPageDetail(int CoverPageId);

        ApiResponse<CoverPageModel> GetCoverPageDetail_filter(int CoverPageId, int plantId, int PlantEquipmentListId, long inputDataId);

        BaseApiResponse SaveCoverPageDetail(CoverPageModel model);

        ApiResponse<CoverPageMachineConfigurationModel> GetCoverPageMachineConfiguration(long? CoverPageId, Int16 lengthUnitId, Int16 pressureUnitId, bool getAllData = false, long? CoverPageIdTool = null);

        ApiResponse<CoverPageMachineConfigurationModel> GetMachineConfigurationForPlasticPressure( Int16 lengthUnitId, Int16 pressureUnitId, long? CoverPageIdTool = null);

        ApiResponse<CoverPageHistoryModel> GetOlderCoverPageByCoverPageId(int CoverPageId, int plantId, int PlantEquipmentListId, int inputDataId);

        ApiResponse<CoverPageMoldFlow> GetMoldFlowPageRecords(string MoldNumber);

         ApiResponse<CoverPageMoldFlow> GetMoldList(int LoggedInUserId);

        ApiResponse<CoverPageDataCountModel> GetCoverPageDataCount(long? CoverPageIdPress, long? CoverPageIdTool);

        ApiResponse<CoverPageModel> GetPlantListDropdown(int? PlantId, bool MoldflowShow,int UserId);

        ApiResponse<CoverPageModel> GetMoldFlowFilter(int PlantId, bool NeedExistingMoldOnly);

        ApiResponse<IMPDRedirectParamsFromInputDataId> GetIMPDRedirectParamsFromInputDataId(long inputDataId);

    }
}
