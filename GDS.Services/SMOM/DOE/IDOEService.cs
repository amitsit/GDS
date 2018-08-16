using GDS.Common;
using GDS.Entities.SMOM.DOE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.DOE
{
    public interface IDOEService
    {
        ApiResponse<DOEModel> GetDOEList(long coverPageId, int lengthUnitId, int pressureUnitId);
        BaseApiResponse SaveDOEModelList(DOEModel model);
        ApiResponse<DOEVariableList> DOEVariableList();
    }
}
