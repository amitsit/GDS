using System.Collections.Generic;
using System.Web.Http;
using GDS.Common;
using GDS.Entities.Master;
using GDS.Entities.SMOM.MoldFlowSetup;
using GDS.Services.SMOM.MoldFlowSetup;
using System.Data;
using System;
using Spire.Xls;
using System.IO;
using System.Web;
using System.Linq;
using static GDS.Entities.SMOM.MoldFlowSetup.MoldFlowInsertFileModel;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class MoldFlowSetupController : ApiController
    {
        #region Initializtions

        private readonly IMoldFlowSetupService _iService;

        public MoldFlowSetupController()
        {
            _iService = EngineContext.Resolve<IMoldFlowSetupService>();
        }

        #endregion

        #region Methods

        #region Mold Flow Header

        [HttpGet]
        [Route("GetMoldFlowListForDropDown")]
        public ApiResponse<MoldFlowHeaderModel> GetMoldFlowListForDropDown()
        {
            return _iService.GetMoldFlowListForDropDown();
        }

        [HttpGet]
        [Route("GetMoldFlowListByProgram")]
        public ApiResponse<MoldFlowHeaderModel> GetMoldFlowListByProgram(long? ProgramId, int? ConversionMode, int UserId)
        {
            return _iService.GetMoldFlowListByProgram(ProgramId, ConversionMode, UserId);
        }


        [HttpGet]
        [Route("CreateMoldFlowHeader_PostProduction")]
        public BaseApiResponse CreateMoldFlowHeader_PostProduction(long? ProgramId, long? InputDataId, int UserId)
        {
            return _iService.CreateMoldFlowHeader_PostProduction(ProgramId, InputDataId, UserId);
        }

        #endregion

        #region Manual Input

        [HttpGet]
        [Route("GetManualInput")]
        public ApiResponse<ManualInputModel> GetManualInput(long moldFlowGeneralInfoId, int lengthUnitId = 1, int pressureUnitId = 1)
        {
            return _iService.GetManualInput(moldFlowGeneralInfoId, lengthUnitId, pressureUnitId);
        }

        [HttpGet]
        [Route("GetManualInputFromGUID")]
        public ApiResponse<ManualInputModel> GetManualInputFromGUID(string GUID, int lengthUnitId = 1, int pressureUnitId = 1)
        {
            return _iService.GetManualInputFromGUID(GUID, lengthUnitId, pressureUnitId);
        }

        [HttpPost]
        [Route("SaveManualInput")]
        public BaseApiResponse SaveManualInput(ManualInputModel model)
        {
            return _iService.SaveManualInput(model);
        }

        #endregion

        #region Valde Gate Position

        [HttpGet]
        [Route("GetValveGatePosition")]
        public ApiResponse<ValveGatePositionModel> GetValveGatePosition(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId)
        {
            return _iService.GetValveGatePosition(moldFlowGeneralInfoId, lengthUnitId, pressureUnitId);
        }

        [HttpGet]
        [Route("GetValveGatePositionFromGUID")]
        public ApiResponse<ValveGatePositionModel> GetValveGatePositionFromGUID(string GUID, int lengthUnitId, int pressureUnitId)
        {
            return _iService.GetValveGatePositionFromGUID(GUID, lengthUnitId, pressureUnitId);
        }

        [HttpPost]
        [Route("SaveValveGatePosition")]
        public BaseApiResponse SaveValveGatePosition(List<ValveGatePositionModel> model, long moldFlowGeneralInfoId, int lengthUnitId = 1, int pressureUnitId = 1, int loggedInUserId = 0)
        {
            return _iService.SaveValveGatePosition(model, moldFlowGeneralInfoId, lengthUnitId, pressureUnitId, loggedInUserId);
        }

        #endregion

        #region General Info
        [HttpGet]
        [Route("ValidateMoldNumber")]
        public BaseApiResponse ValidateMoldNumber(string MoldNumber, long? MoldFlowGeneralInfoId)
        {
            return _iService.ValidateMoldNumber(MoldNumber, MoldFlowGeneralInfoId);
        }

        [HttpGet]
        [Route("GetMoldFlowGeneralInfo")]
        public ApiResponse<MoldFlowGeneralInfoModel> GetMoldFlowGeneralInfo(long moldFlowGeneralInfoId, int lengthUnitId = 1, int pressureUnitId = 1)
        {
            return _iService.GetMoldFlowGeneralInfo(moldFlowGeneralInfoId, lengthUnitId, pressureUnitId);
        }

        [HttpGet]
        [Route("GetMoldFlowGeneralInfoFromGUID")]
        public ApiResponse<MoldFlowGeneralInfoModel> GetMoldFlowGeneralInfoFromGUID(string GUID)
        {
            return _iService.GetMoldFlowGeneralInfoFromGUID(GUID);
        }


        [HttpPost]
        [Route("SaveMoldFlowGeneralInfo")]
        public BaseApiResponse SaveMoldFlowGeneralInfo(int? FinalizeMoldflowSetup, bool? IsExistingMold, MoldFlowGeneralInfoModel model)
        {
            return _iService.SaveMoldFlowGeneralInfo(FinalizeMoldflowSetup, IsExistingMold, model);
        }

        #endregion

        #region Shot Position
        [HttpGet]
        [Route("GetMoldFlowShotPosition")]
        public ApiResponse<MoldFlowShotPositioinModel> GetMoldFlowShotPosition(long moldFlowGeneralInfoId, int lengthUnitId = 1, int pressureUnitId = 1)
        {
            return _iService.GetMoldFlowShotPosition(moldFlowGeneralInfoId, lengthUnitId, pressureUnitId);
        }

        [HttpGet]
        [Route("GetMoldFlowShotPositionFromGUID")]
        public ApiResponse<MoldFlowShotPositioinModel> GetMoldFlowShotPositionFromGUID(string GUID, int lengthUnitId = 1, int pressureUnitId = 1)
        {
            return _iService.GetMoldFlowShotPositionFromGUID(GUID, lengthUnitId, pressureUnitId);
        }

        [HttpPost]
        [Route("SaveMoldFlowShotPosition")]
        public BaseApiResponse SaveMoldFlowShotPosition(MoldFlowShotPositioinModel model)
        {
            return _iService.SaveMoldFlowShotPosition(model);
        }
        #endregion

        #region Pressure
        [HttpGet]
        [Route("GetMoldFlowPressure")]
        public ApiResponse<MoldFlowPressureModel> GetMoldFlowPressure(long moldFlowGeneralInfoId, int lengthUnitId = 1, int pressureUnitId = 1)
        {
            return _iService.GetMoldFlowPressure(moldFlowGeneralInfoId, lengthUnitId, pressureUnitId);
        }

        [HttpGet]
        [Route("GetMoldFlowPressureFromGUID")]
        public ApiResponse<MoldFlowPressureModel> GetMoldFlowPressureFromGUID(string GUID, int lengthUnitId = 1, int pressureUnitId = 1)
        {
            return _iService.GetMoldFlowPressureFromGUID(GUID, lengthUnitId, pressureUnitId);
        }

        [HttpPost]
        [Route("SaveMoldFlowPressure")]
        public BaseApiResponse SaveMoldFlowPressure(MoldFlowPressureModel model)
        {
            return _iService.SaveMoldFlowPressure(model);
        }

        #endregion

        #region Timer
        [HttpGet]
        [Route("GetMoldFlowTimer")]
        public ApiResponse<MoldFlowTimerModel> GetMoldFlowTimer(long moldFlowGeneralInfoId, int lengthUnitId = 1, int pressureUnitId = 1)
        {
            return _iService.GetMoldFlowTimer(moldFlowGeneralInfoId, lengthUnitId, pressureUnitId);
        }

        [HttpGet]
        [Route("GetMoldFlowTimerFromGUID")]
        public ApiResponse<MoldFlowTimerModel> GetMoldFlowTimerFromGUID(string GUID, int lengthUnitId = 1, int pressureUnitId = 1)
        {
            return _iService.GetMoldFlowTimerFromGUID(GUID, lengthUnitId, pressureUnitId);
        }

        [HttpPost]
        [Route("SaveMoldFlowTimer")]
        public BaseApiResponse SaveMoldFlowTimer(MoldFlowTimerModel model)
        {
            return _iService.SaveMoldFlowTimer(model);
        }
        #endregion

        #region Get Mold Flow Version

        [HttpGet]
        [Route("GetMoldFlowVersionList")]
        public ApiResponse<MoldFlowVersionModel> GetMoldFlowVersionList(long MoldFlowHeaderId)
        {
            return _iService.GetMoldFlowVersion(MoldFlowHeaderId);
        }

        #endregion

        #region Get Mold Flow UploadFile and ReadFile
        [HttpPost]
        [Route("UploadMoldFlowDataFile")]
        public BaseApiResponse UploadMoldFlowDataFile(int UserId)
        {
            MoldFlowInsertFileModel MoldFlowFileModel = new MoldFlowInsertFileModel();
            List<ValveGatePositionsCell> Valvegatelist = new List<ValveGatePositionsCell>();
            var directoryPath = System.Web.HttpContext.Current.Server.MapPath("~/TempFiles");
            //  DataTable datatable = null;
            if (!System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
            }
            string filePath = directoryPath + @"\" + Guid.NewGuid().ToString() + ".xlsx";

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {

                var httpPostedFile = HttpContext.Current.Request.Files[0];
                httpPostedFile.SaveAs(filePath);
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(filePath);
                Worksheet sheet = workbook.Worksheets["MoldFlow SetUp"];
                //Spire.Xls.Collections.WorksheetsCollection Wssheets = workbook.Worksheets;
                //Worksheet sheet = workbook.

                MoldFlowFileModel.UserId = UserId;
                MoldFlowFileModel.MoldFlowSetup_GeneralInfo_PlantName = sheet.Range["F5"].HasFormula ? Convert.ToString(sheet.Range["F5"].FormulaValue) : Convert.ToString(sheet.Range["F5"].Value);
                MoldFlowFileModel.MoldFlowSetup_GeneralInfo_MoldNumber = sheet.Range["F6"].HasFormula ? Convert.ToString(sheet.Range["F6"].FormulaValue) : Convert.ToString(sheet.Range["F6"].Value);
                MoldFlowFileModel.MoldFlowSetup_GeneralInfo_JobName = sheet.Range["F7"].HasFormula ? Convert.ToString(sheet.Range["F7"].FormulaValue) : Convert.ToString(sheet.Range["F7"].Value);
                MoldFlowFileModel.MoldFlowSetup_GeneralInfo_PressNumber = sheet.Range["F8"].HasFormula ? Convert.ToString(sheet.Range["F8"].FormulaValue) : Convert.ToString(sheet.Range["F8"].Value);
                MoldFlowFileModel.MoldFlowSetup_GeneralInfo_Date = sheet.Range["F9"].HasFormula ? Convert.ToString(sheet.Range["F9"].FormulaValue) : Convert.ToString(sheet.Range["F9"].Value);
                MoldFlowFileModel.MoldFlowSetup_GeneralInfo_MaterialName = sheet.Range["F10"].HasFormula ? Convert.ToString(sheet.Range["F10"].FormulaValue) : Convert.ToString(sheet.Range["F10"].Value);

                MoldFlowFileModel.MoldFlowSetup_MoldTemp_Stationary = sheet.Range["O19"].HasFormula ? Convert.ToDouble(sheet.Range["O19"].FormulaValue) : Convert.ToDouble(sheet.Range["O19"].Value);
                MoldFlowFileModel.MoldFlowSetup_MoldTemp_Moveable = sheet.Range["O20"].HasFormula ? Convert.ToDouble(sheet.Range["O20"].FormulaValue) : Convert.ToDouble(sheet.Range["O20"].Value);

                MoldFlowFileModel.MoldFlowSetup_ShotPosition_ShotSize = sheet.Range["C24"].HasFormula ? Convert.ToDouble(sheet.Range["C24"].FormulaValue) : Convert.ToDouble(sheet.Range["C24"].Value);
                MoldFlowFileModel.MoldFlowSetup_ShotPosition_Transfer = sheet.Range["C25"].HasFormula ? Convert.ToDouble(sheet.Range["C25"].FormulaValue) : Convert.ToDouble(sheet.Range["C25"].Value);
                MoldFlowFileModel.MoldFlowSetup_ShotPosition_Cushion = sheet.Range["C27"].HasFormula ? Convert.ToDouble(sheet.Range["C27"].FormulaValue) : Convert.ToDouble(sheet.Range["C27"].Value);
                MoldFlowFileModel.MoldFlowSetup_ShotPosition_CubicVolumnTransfer = sheet.Range["C28"].HasFormula ? Convert.ToDouble(sheet.Range["C28"].FormulaValue) : Convert.ToDouble(sheet.Range["C28"].Value);
                MoldFlowFileModel.MoldFlowSetup_ShotPosition_TotalCubicVolumn = sheet.Range["C29"].HasFormula ? Convert.ToDouble(sheet.Range["C29"].FormulaValue) : Convert.ToDouble(sheet.Range["C29"].Value);
                MoldFlowFileModel.MoldFlowSetup_ShotPosition_ShrinkRateMoldIsCutTo = sheet.Range["C30"].HasFormula ? Convert.ToDouble(sheet.Range["C30"].FormulaValue) : Convert.ToDouble(sheet.Range["C30"].Value);
                MoldFlowFileModel.MoldFlowSetup_ShotPosition_MeltSolidRatio = sheet.Range["C31"].HasFormula ? Convert.ToDouble(sheet.Range["C31"].FormulaValue) : Convert.ToDouble(sheet.Range["C31"].Value);
                MoldFlowFileModel.MoldFlowSetup_ShotPosition_VolumefromAnalysisin3 = sheet.Range["C32"].HasFormula ? Convert.ToDouble(sheet.Range["C32"].FormulaValue) : Convert.ToDouble(sheet.Range["C32"].Value);
                MoldFlowFileModel.MoldFlowSetup_ShotPosition_MeltDensity = sheet.Range["C33"].HasFormula ? Convert.ToDouble(sheet.Range["C33"].FormulaValue) : Convert.ToDouble(sheet.Range["C33"].Value);
                MoldFlowFileModel.MoldFlowSetup_ShotPosition_SolidDensity = sheet.Range["C34"].HasFormula ? Convert.ToDouble(sheet.Range["C34"].FormulaValue) : Convert.ToDouble(sheet.Range["C34"].Value);

                MoldFlowFileModel.MoldFlow_Pressure_HydraulicTransfer = sheet.Range["F25"].HasFormula ? Convert.ToDouble(sheet.Range["F25"].FormulaValue) : Convert.ToDouble(sheet.Range["F25"].Value);
                MoldFlowFileModel.MoldFlow_Pressure_PlasticTransfer = sheet.Range["G25"].HasFormula ? Convert.ToDouble(sheet.Range["G25"].FormulaValue) : Convert.ToDouble(sheet.Range["G25"].Value);
                MoldFlowFileModel.MoldFlow_Pressure_HydraulicPack = sheet.Range["F26"].HasFormula ? Convert.ToDouble(sheet.Range["F26"].FormulaValue) : Convert.ToDouble(sheet.Range["F26"].Value);
                MoldFlowFileModel.MoldFlow_Pressure_PlasticPack = sheet.Range["G26"].HasFormula ? Convert.ToDouble(sheet.Range["G26"].FormulaValue) : Convert.ToDouble(sheet.Range["G26"].Value);
                MoldFlowFileModel.MoldFlow_Pressure_HydaulicHold = sheet.Range["F27"].HasFormula ? Convert.ToDouble(sheet.Range["F27"].FormulaValue) : Convert.ToDouble(sheet.Range["F27"].Value);
                MoldFlowFileModel.MoldFlow_Pressure_PlasticHold = sheet.Range["G27"].HasFormula ? Convert.ToDouble(sheet.Range["G27"].FormulaValue) : Convert.ToDouble(sheet.Range["G27"].Value);
                MoldFlowFileModel.MoldFlow_Pressure_HydaulicTonnage = sheet.Range["F29"].HasFormula ? Convert.ToDouble(sheet.Range["F29"].FormulaValue) : Convert.ToDouble(sheet.Range["F29"].Value);
                MoldFlowFileModel.MoldFlow_Pressure_PlasticTonnage = sheet.Range["G29"].HasFormula ? Convert.ToDouble(sheet.Range["G29"].FormulaValue) : Convert.ToDouble(sheet.Range["G29"].Value);

                MoldFlowFileModel.MoldFlow_Timer_Fill = sheet.Range["K24"].HasFormula ? Convert.ToDouble(sheet.Range["K24"].FormulaValue) : Convert.ToDouble(sheet.Range["K24"].Value);
                MoldFlowFileModel.MoldFlow_Timer_Pack = sheet.Range["K25"].HasFormula ? Convert.ToDouble(sheet.Range["K25"].FormulaValue) : Convert.ToDouble(sheet.Range["K25"].Value);
                MoldFlowFileModel.MoldFlow_Timer_Hold = sheet.Range["K26"].HasFormula ? Convert.ToDouble(sheet.Range["K26"].FormulaValue) : Convert.ToDouble(sheet.Range["K26"].Value);
                MoldFlowFileModel.MoldFlow_Timer_Cooling = sheet.Range["K27"].HasFormula ? Convert.ToDouble(sheet.Range["K27"].FormulaValue) : Convert.ToDouble(sheet.Range["K27"].Value);
                MoldFlowFileModel.VIPOfAnalysis = sheet.Range["D25"].DisplayedText != null ? Convert.ToString(sheet.Range["D25"].DisplayedText) : "";
                CellRange crValueData = sheet.Range[42, 7, 69, 12];
                
                int count = 0;
                for(int i=0;i<28;i++)
                {
                    var valvePara = new ValveGatePositionsCell();

                    //valvePara.OpenVolumePercentage = crValueData.Cells[count].DisplayedText !=null ? Convert.ToDouble(crValueData.Cells[count].DisplayedText) : Convert.ToDouble(crValueData.Cells[count].Value);
                    //valvePara.ZoneName = crValueData.Cells[count + 1].HasFormula ? Convert.ToString(crValueData.Cells[count + 1].DisplayedText) : Convert.ToString(crValueData.Cells[count + 1].Value);
                    //valvePara.OpenPosition = crValueData.Cells[count + 2].HasFormula ? Convert.ToDouble(crValueData.Cells[count + 2].DisplayedText) : Convert.ToDouble(crValueData.Cells[count + 2].Value);
                    //valvePara.ClosePosition = crValueData.Cells[count + 3].HasFormula ? Convert.ToDouble(crValueData.Cells[count + 3].DisplayedText) : Convert.ToDouble(crValueData.Cells[count + 3].Value);
                    //valvePara.PackTime = crValueData.Cells[count + 4].HasFormula ? Convert.ToDouble(crValueData.Cells[count + 4].DisplayedText) : Convert.ToDouble(crValueData.Cells[count + 4].Value);
                    //valvePara.CloseVolumePercentage = crValueData.Cells[count + 5].HasFormula ? Convert.ToDouble(crValueData.Cells[count + 5].DisplayedText) : Convert.ToDouble(crValueData.Cells[count + 5].Value);

                    valvePara.OpenVolumePercentage = crValueData.Cells[count].DisplayedText != null ? Convert.ToString(crValueData.Cells[count].DisplayedText) :"";
                    valvePara.ZoneName = crValueData.Cells[count + 1].DisplayedText != null ? Convert.ToString(crValueData.Cells[count + 1].DisplayedText) : "";
                    valvePara.OpenPosition = crValueData.Cells[count + 2].DisplayedText != null ? Convert.ToString(crValueData.Cells[count + 2].DisplayedText) :"";
                    valvePara.ClosePosition = crValueData.Cells[count + 3].DisplayedText != null ? Convert.ToString(crValueData.Cells[count + 3].DisplayedText) : "";
                    valvePara.PackTime = crValueData.Cells[count + 4].DisplayedText != null ? Convert.ToString(crValueData.Cells[count + 4].DisplayedText) : "";
                    valvePara.CloseVolumePercentage = crValueData.Cells[count + 5].DisplayedText != null ? Convert.ToString(crValueData.Cells[count + 5].DisplayedText) : "";
                    Valvegatelist.Add(valvePara);
                    count = count + 6;
                }

                MoldFlowFileModel.Valvegatelist = Valvegatelist;

            }
            return _iService.UploadMoldFlowDataFile(MoldFlowFileModel);
        }

        #endregion

        #endregion
    }
}
