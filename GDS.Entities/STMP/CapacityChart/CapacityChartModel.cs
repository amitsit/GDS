using System.Collections.Generic;
using GDS.Entities.STMP.PressBreakDown;

namespace GDS.Entities.STMP.CapacityChart
{
    public class CapacityChartModel
    {
        public List<PressBreakDownModel> PressBreakDownModel { get; set; }
        public List<PressManSummaryModel> PressManSummaryModel { get; set; }
    }

    public class DateListModel
    {
        public string DateId { get; set; }
        public string DateList { get; set; }
    }
}
