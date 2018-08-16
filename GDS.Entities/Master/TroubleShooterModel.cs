namespace GDS.Entities.Master
{
    using System;
    public class TroubleShooterModel
    {
        public long TroubleShooterId { get; set; }
        public int PlantId { get; set; }
        public int UserId { get; set; }
        public string PlantName { get; set; }
        public string PageName { get; set; }
        public string TroubleShooterButtonName { get; set; }
        public string TroubleShooterDescription { get; set; }
        public string LanguageCd { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LanguageName { get; set; }
    }
}
