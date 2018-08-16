using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.PartAndMoldTemperatureMapping
{
    public class PartAndMoldTemperatureModel
    {
        public int? PartAndMoldTemperatureId { get; set; }
        public int? PartAndMoldTemperatureMapId { get; set; }
        public string Notes { get; set; }
        public int Type { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
        public double? Temperature1 { get; set; }
        public double? Temperature2 { get; set; }
        public double? Temperature3 { get; set; }
        public double? Temperature4 { get; set; }
        public double? Temperature5 { get; set; }
        public double? Temperature6 { get; set; }
        public string MoldTemperatureDataPartLeft { get; set; }
        public string MoldTemperatureDataPartRight { get; set; }
        public string PartTemperatureData { get; set; }
        public string MoldTemperatureDataPartLeftImagePath { get; set; }
        public string MoldTemperatureDataPartRightImagePath { get; set; }
        public string PartTemperatureDataImagePath { get; set; }
        public int? PartAndMoldTemperatureDataId { get; set; }


        public string MoldTemperatureDataPartTitle { get; set; }
        public string MoldTempratureDataPartImagePath { get; set; }
        public string MoldTemperatureDataPartHtmlContent { get; set; }
    }
}
