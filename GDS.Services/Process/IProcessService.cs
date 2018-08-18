using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Process
{
   public interface IProcessService
    {
        ApiResponse<ProcessModel> GetProcesses(int? MenuId);
    }
}
