using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GDS.Entities.IMIP
{
    public class BICVerificationDocumentModel
    {
        public long BICVerificationDocumentId { get; set; }
        public byte TypeId { get; set; }
        public long? CoverPageId { get; set; }
        public int PlantId { get; set; }
        public int ProgramId { get; set; }
        public string Part { get; set; }
        public long MoldNumber { get; set; }
        public string ToolNumber { get; set; }
        public int PlantEquipmentListId { get; set; }
        public double Tonnage { get; set; }
        public double WallStockMM { get; set; }
        public bool InsertMolding { get; set; }
        public double CurrentCycleSec { get; set; }
        public int? CTThicknessAddSec { get; set; }
        public double InsertMoldingAddSec { get; set; }
        public int BICCycleTime { get; set; }
        public int WCCycleTime { get; set; }
        public double? NeedImprovementBy { get; set; }
        public byte[] Image { get; set; }
        public DateTime? BaselineDate { get; set; }
        public DateTime? ImprovedDate { get; set; }
        public byte? ValidationStatusCode { get; set; }

        public int LoggedInUserId { get; set; }

        public List<BICVerificationDocumentBreakDown> BICVerificationDocumentBreakDownList { get; set; }
        public List<BICVerificationQuestionAnswerModel> BICVerificationQuestionAnswerList { get; set; }

        public List<BICVerificationDocumentBreakdownRecord> BICVerificationDocumentBreakdownRecordList { get; set; }

        private string BreakDownStr
        {
            set
            {
                BICVerificationDocumentBreakdownRecordList = !string.IsNullOrEmpty(value)
                    ? Common.Utility.DeserializeFromXMLNew<BICVerificationDocumentBreakdown>(value).BICVerificationDocumentBreakdownList
                    : new List<BICVerificationDocumentBreakdownRecord>();
            }
        }

        public string PlantName { get; set; }
        public string ProgramName { get; set; }
    }

    public class BICVerificationDocumentImagesModel
    {
        public long BICVerificationDocumentImagesId { get; set; }
        public long? BICVerificationDocumentId { get; set; }
        public long? CoverPageId { get; set; }
        public byte[] Image { get; set; }
    }

    public class MoldNumberDDLModel
    {
        public int PlantId { get; set; }
        public long MoldNumber { get; set; }
        public string MoldNumberDesc { get; set; }
        public string Part { get; set; }
    }

    public class InputDataProgramModel
    {
        public long ProgramID { get; set; }
        public string ProgramName { get; set; }
    }

    public class CTPartThicknessModel
    {
        public int WallStockId { get; set; }
        public int MaterialTypeId { get; set; }
        public double FromRangeMM { get; set; }
        public double ToRangeMM { get; set; }
        public double CTValue { get; set; }
    }

    public class BICVerificationDocumentBreakDown
    {
        //public long BICVerificationDocumentBreakdownId { get; set; }
        //public long BICVerificationDocumentId { get; set; }
        public int BICCycleKeyElementID { get; set; }
        public double? BIC { get; set; }
        public double? BaselineActual { get; set; }
        public double? ImprovedActual { get; set; }
    }

    [XmlRoot("BICVerificationDocumentBreakdown")]
    public class BICVerificationDocumentBreakdown
    {
        public BICVerificationDocumentBreakdown() { BICVerificationDocumentBreakdownList = new List<BICVerificationDocumentBreakdownRecord>(); }

        [XmlElement("BICVerificationDocumentBreakdownRecord", typeof(BICVerificationDocumentBreakdownRecord))]
        public List<BICVerificationDocumentBreakdownRecord> BICVerificationDocumentBreakdownList { get; set; }
    }

    public class BICVerificationDocumentBreakdownRecord
    {
        [XmlElement("BICCycleKeyElementId")]
        public int? BICCycleKeyElementId { get; set; }
        [XmlElement("BIC")]
        public double? BIC { get; set; }
        [XmlElement("BaselineActual")]
        public double? BaselineActual { get; set; }
        [XmlElement("ImprovedActual")]
        public double? ImprovedActual { get; set; }
        [XmlElement("ElementName")]
        public string ElementName { get; set; }
        [XmlElement("decimalAllow")]
        public string decimalAllow { get; set; }
        [XmlElement("NeedToSuccess")]
        public string NeedToSuccess { get; set; }
    }
}
