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

        ApiResponse<SubProcessModel> GetSubProcessListByStatus(int? ProcessId, int? RegionId, int? UserId ,bool? IsActive);

        ApiResponse<DocumentMasterModel> GetProcessDocumentBySubProcessIdAndRegionId(int? SubProcessId, int? RegionId, int? UserId, bool? IsActive);

        BaseApiResponse DeleteSubProcessFromRegion(int SubProcessId, int RegionId, int UserId);

        ApiResponse<SubProcessModel> SaveSubProcessDetail(int UserId,SubProcessModel SubProcessObj);

        BaseApiResponse DeleteSubProcess(int? ProcessId, int? SubProcessId, int? UserId);

        BaseApiResponse SaveDocument(int UserId, ProcessDocument ProcessDocumentObj);

        BaseApiResponse DeleteDocument(int UserId, int SubProcessDocumentId);
    }
}
