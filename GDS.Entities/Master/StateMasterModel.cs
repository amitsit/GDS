namespace GDS.Entities.Master
{
    using System;
    public class StateMasterModel
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
