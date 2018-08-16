using System;
using System.ComponentModel.DataAnnotations;

namespace GDS.Entities.Master
{
    public class CityMasterModel
    {


        #region Instance Properties
    
        public Int32 CityID { get; set; }

        public String CityName { get; set; }


        public Int32 CountryID { get; set; }



        public DateTime CreatedDate { get; set; }


        public Int32 CreatedBy { get; set; }
     
        public DateTime? UpdatedDate { get; set; }

        public Int32? UpdateBy { get; set; }

        #endregion Instance Properties
    }

}
