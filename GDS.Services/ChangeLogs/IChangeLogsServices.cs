using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.ChangeLogs
{
    public interface IChangeLogsServices
    {
        ApiResponse<ChangeLogsModel> GetChangeLogs(int? UserId);

        ApiResponse<ChangeLogsModel> GetChangeLogsDetail(string GUID,int? UserId);

        BaseApiResponse DeleteChangeLog(string GUID, int? UserId);

        BaseApiResponse SaveChangeLog(int? UserId, ChangeLogsModel ChangeLogObj);

    }
}
