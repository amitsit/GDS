﻿using GDS.Common;
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
        ApiResponse<ProcessModel> GetProcesses(int? MenuId,bool? IsActive);
        ApiResponse<ProcessModel> GetProcessesListByStatus(int? MenuId, bool? IsActive);
        ApiResponse<SubProcessModel> GetSubProcesses(int? ProcessId);
        ApiResponse<ProcessModel> GetProcessOrSubProcessListByProcessId(int? MenuId, int? ProcessId, int? UserId);
        BaseApiResponse SaveProcessDetail(int? UserId, ProcessModel ProceeObj);
        BaseApiResponse DeleteProcess(int ProcessId, int UserId);
        
    }
}
