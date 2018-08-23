using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SubProcess
{
    public interface ISubProcessService
    {
        ApiResponse<SubProcessModel> GetSubProcess(int? ProcessId, int? SubProcessId, int? RegionId, int? UserId);

        ApiResponse<ProcessDocument> GetProcessDocumentBySubProcessIdAndRegionId(int? SubProcessId, int? RegionId, int? UserId);
    }
}
