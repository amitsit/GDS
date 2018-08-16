namespace GDS.Entities.Master
{
    public class MaterialTypeMasterModel
    {
        public int MaterialTypeId { get; set; }
        public string MaterialTypeCode { get; set; }
        public string MaterialTypeDescription { get; set; }
        public bool IsActive { get; set; }
        public int LoggedInUserId { get; set; }
    }
}
