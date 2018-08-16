using System.Collections.Generic;
using GDS.Common;
using GDS.Entities.SMOM.MoldFlowSetup;
using static GDS.Entities.SMOM.MoldFlowSetup.MoldFlowInsertFileModel;

namespace GDS.Services.SMOM.MoldFlowSetup
{
    public interface IMoldFlowSetupService
    {
        // Mold Flow Header

        ApiResponse<MoldFlowHeaderModel> GetMoldFlowListForDropDown();
        ApiResponse<MoldFlowHeaderModel> GetMoldFlowListByProgram(long? ProgramId, int? ConversionMode, int UserId);

        // Manual Input

        ApiResponse<ManualInputModel> GetManualInput(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId);
        ApiResponse<ManualInputModel> GetManualInputFromGUID(string GUID, int lengthUnitId, int pressureUnitId);

        BaseApiResponse SaveManualInput(ManualInputModel model);

        // Valve Gate Position

        ApiResponse<ValveGatePositionModel> GetValveGatePosition(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId);
        ApiResponse<ValveGatePositionModel> GetValveGatePositionFromGUID(string GUID, int lengthUnitId, int pressureUnitId);
        BaseApiResponse SaveValveGatePosition(List<ValveGatePositionModel> model, long moldFlowGeneralInfoId, int lengthUnitId,int pressureUnitId , int loggedInUserId);


        //General Info
        ApiResponse<MoldFlowGeneralInfoModel> GetMoldFlowGeneralInfo(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId);
        ApiResponse<MoldFlowGeneralInfoModel> GetMoldFlowGeneralInfoFromGUID(string GUID);

        BaseApiResponse SaveMoldFlowGeneralInfo(int? FinalizeMoldflowSetup, bool? IsExistingMold, MoldFlowGeneralInfoModel model);

        //Shot Position
        ApiResponse<MoldFlowShotPositioinModel> GetMoldFlowShotPosition(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId);
        ApiResponse<MoldFlowShotPositioinModel> GetMoldFlowShotPositionFromGUID(string GUID, int lengthUnitId, int pressureUnitId);

        BaseApiResponse SaveMoldFlowShotPosition(MoldFlowShotPositioinModel model);


        //Pressure
        ApiResponse<MoldFlowPressureModel> GetMoldFlowPressure(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId);
        ApiResponse<MoldFlowPressureModel> GetMoldFlowPressureFromGUID(string GUID, int lengthUnitId, int pressureUnitId);
        BaseApiResponse SaveMoldFlowPressure(MoldFlowPressureModel model);

        //Timer
        ApiResponse<MoldFlowTimerModel> GetMoldFlowTimer(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId);
        ApiResponse<MoldFlowTimerModel> GetMoldFlowTimerFromGUID(string GUID, int lengthUnitId, int pressureUnitId);
        BaseApiResponse SaveMoldFlowTimer(MoldFlowTimerModel model);

        // Mold Flow Version List
        ApiResponse<MoldFlowVersionModel> GetMoldFlowVersion(long moldFlowHeaderId);
        BaseApiResponse ValidateMoldNumber(string MoldNumber,long? MoldFlowGeneralInfoId);

        BaseApiResponse CreateMoldFlowHeader_PostProduction(long? ProgramId, long? InputDataId, int UserId);


        //File Upload and Read
        BaseApiResponse UploadMoldFlowDataFile(MoldFlowInsertFileModel MoldFlowFileModel);
    }
}
