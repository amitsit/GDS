namespace GDS.Entities.Master
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CountryMasterModel
    {

        #region Instance Properties


        public Int32? CountryID { get; set; }


        public String CountryName { get; set; }


        public Int32? RegionID { get; set; }

        public bool? IsActive { get; set; }

        public String RegionName { get; set; }


        public DateTime? CreatedDate { get; set; }


        public Int32? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }


        public Int32? ModifiedBy { get; set; }

        public string SelectedRegion { get; set; }

        #endregion Instance Properties
    }
}
