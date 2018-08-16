namespace GDS.Entities.IMIP
{
    using System;
    public class BICVerificationQuestionAnswerModel
    {
        #region Instance Properties
        public long? BICDocumentVerificationQuestionAnswerId { get; set; }
        public int? BICVerificationDocumentId { get; set; }
        public int BICVerificationQuestionId { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        #endregion
    }
}
