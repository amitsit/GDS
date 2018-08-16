using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
    public class ColorCodeSchemeModel
    {
        public long ColorCodeSchemeId { get; set; }
        public string PageName { get; set; }
        public string FieldName { get; set; }
        public double? FromValue { get; set; }
        public double? ToValue { get; set; }
        public string Expression { get; set; }
        public byte LengthUnitId { get; set; }
        public string ResultText { get; set; }
        public byte? ResultTextId { get; set; }
        public string ColorCode { get; set; }
    }
}
