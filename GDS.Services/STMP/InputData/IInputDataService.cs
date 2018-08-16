using GDS.Entities.STMP.InputData;

namespace GDS.Services.STMP.InputData
{
    using Common;
    using Entities;
    using Entities.Master;

    public interface IInputDataService
    {
        ApiResponse<STMPInputDataModel> GetInputData(long? inputDataId);

        ApiResponse<STMPInputDataModel> GetInputDataList(int UserId, int PlantId, string sortColumn,string searchValue, TableParameter<STMPInputDataModel> tableParameter);

        ApiResponse<ProgramMasterModel> GetPrograms();

        BaseApiResponse SaveInputData(STMPInputDataModel model);
        BaseApiResponse SaveInputData_InitialDataConverstion(bool? IsExistingMold, int? MoldFlowSetupHeaderId, STMPInputDataModel model);

        BaseApiResponse DeleteInputData(long inputDataId);

        ApiResponse<STMPInputDataModel> GetMoldByProgramAndPlant(int? PlantId,long? ProgramID,int LoggedInUserId);
        BaseApiResponse UploadInputDataFile(string datatableToxml, int UserId);


    }
}
