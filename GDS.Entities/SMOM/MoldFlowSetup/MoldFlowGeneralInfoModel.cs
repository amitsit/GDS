using GDS.Entities.Master;
using System;
using System.Collections.Generic;

namespace GDS.Entities.SMOM.MoldFlowSetup
{
    public class MoldFlowHeaderModel
    {
        public int? MoldFlowSetupHeaderId { get; set; }
        public string MoldFlowNumber { get; set; }
        public long? MoldFlowGeneralInfoId { get; set; }      
        public long? InitDataGeneralInfoId { get; set; }
        public int? FinalizeMoldflowSetup { get; set; }
        public bool? IsFinalizedConversionSetup { get; set; }
        public bool? IsExistingMold { get; set; }
        public bool? IsPushedToProducton { get; set; }
        public long? CoverPageId { get; set; }
        public bool? IsInitialDataConversionHistoryAvailable { get; set; }
        public long? InputDataId { get; set; }
        public bool? IsVoidCalculative { get; set; }
        public bool? chkIsVoidCalculative { get; set; }
    }

    public class MoldFlowGeneralInfoModel : UnitTypeModel 
    {
        public long MoldFlowGeneralInfoId { get; set; }
        public long? ProgramID { get; set; }
        public int? PlantId { get; set; }
        public string MoldNumber { get; set; }
        public string JobName { get; set; }
        public string IdentificationText { get; set; }
        public long? PlantEquipmentListId { get; set; }
        public int? MoldFlowSetupHeaderId { get; set; }
        public DateTime Date { get; set; }
        public int? MaterialId { get; set; }
        public double? SpecificGravity { get; set; }
        public double? MeltDensity { get; set; }
        public int LoggedInUserId { get; set; }
        public string SpecialNote_Issue { get; set; }
        public bool? IsExistingMold { get; set; }
        public bool? MoldIsAlreadyInProduction { get; set; }
        public bool? IsVoidCalculative { get; set; }
        public bool? chkIsVoidCalculative { get; set; }
    }
  

   
}
