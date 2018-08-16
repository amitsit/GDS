using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.DOEVariableMaster
{
   public interface IDOEVariableMasterService
    {
        ApiResponse<DOEVariableMasterModel> GetDOEVariableType();
        ApiResponse<DOEVariableMasterModel> GetDOEVariableMasterById(int VariableId);
        ApiResponse<DOEVariableMasterModel> GetDOEVariableMasterList();
        BaseApiResponse SaveDOEVariableMaster(DOEVariableMasterModel dOEVariableModel);
    }
}
