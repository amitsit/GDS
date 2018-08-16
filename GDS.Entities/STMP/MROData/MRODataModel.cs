using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.STMP.MROData
{
    public class MRODataModel
    {
        public int LoggedInUserId { get; set; }
        public int PlantId { get; set; }
        public List<MRODataList> MRODataList { get; set; }
    }

    public class MRODataList
    {
        public string PressNumber { get; set; }
        public long PlantEuipmentListId { get; set; }
        public double? Tonnage { get; set; }
        public double? LaborHrs { get; set; }
        public double? Cost54 { get; set; }
        public double? ServiceCost { get; set; }
        public int? PlantId { get; set; }
        public int? MRODataId { get; set; }
    }
}
