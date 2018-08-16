using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.PartAndMoldTemperatureMapping
{
    public class PartAndMoldTemperatureMapModel
    {
        public int? PartAndMoldTemperatureMapId { get; set; }
        public int? CoverPageId { get; set; }
        public DateTime? Date { get; set; }
        public string Notes { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string MoldTemperatureDataPartLeft { get; set; }
        public string MoldTemperatureDataPartRight { get; set; }
        public string PartTemperatureData { get; set; }
        public string MoldTemperatureDataPartLeftImagePath { get; set; }
        public string MoldTemperatureDataPartRightImagePath { get; set; }
        public string PartTemperatureDataImagePath { get; set; }

        public string MoldTemperatureDataPartTitle { get; set; }
        public string MoldTempratureDataPartImagePath { get; set; }
        public string MoldTemperatureDataPartHtmlContent { get; set; }
        


        public int? PartAndMoldTemperatureDataId { get; set; }
        public List<PartAndMoldTemperatureModel> PartAndMoldTemperatureDetail { get; set; }

        public bool IsDOEData { get; set; }
    }
}
