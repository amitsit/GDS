namespace GDS.Services.STMP.PlantEquipmentList
{
    using Common;
    using Entities;
    using GDS.Entities.STMP.PlantEquipmentList;
    using System.Collections.Generic;
    using System.Data;
    public interface IPlantEquipmentListService
    {
        ApiResponse<STMPPlantEquipmentListModel> GetPlantEquipmentList(int? plantId, long? plantEquipmentListId);

        BaseApiResponse InsertPlanEquipmentListMaster(int UserId, List<STMPPlantEquipmentListMasterModel> dataObjects);

        BaseApiResponse InsertPlanEquipmentList(int plantId);

        BaseApiResponse UploadPlantEquipmentFile(DataTable dtResult, int UserId);

        ApiResponse<PlantEquipmentForDDLModel> GetPlantEquipmentListForDDL(int plantId, long bicVerificationDocumentId, long coverPageId);

        BaseApiResponse InsertOrUpdatePlantEquipmentList(PlantEquipmentMasterModel model);

        BaseApiResponse DeletePlantEquipment(int PlantEquipmentListId);

        ApiResponse<PlantEquipmentMasterModel> GetPlantEquipmentServerPagination(int plantId, int pageIndex, int pageSize,string SearchColumnName ,string searchFor, string orderByColumn, bool orderByAscDirection);

        ApiResponse<PlantEquipmentColumnListModel> GetPlantEquipmentColumnList();
    }
}
