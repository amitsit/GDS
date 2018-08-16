using System;
using System.ComponentModel.DataAnnotations;

namespace GDS.Entities.Master
{
    public class RegionMasterModel
    {
        #region Instance Properties
 
        public Int32 RegionID { get; set; }

        public String RegionName { get; set; }

        public string RegionIdCsv { get; set; }

        public bool? IsActive { get; set; }

        public Int32? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Int32? UpdatedBy { get; set; }

        public bool? IsSelected { get; set; }

        #endregion Instance Properties
    }

}
