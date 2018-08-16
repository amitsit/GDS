using GDS.Common;
using GDS.Entities.Master;
using GDS.Entities.SMOM.CorpIMPD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.CorpIMPD
{
    public interface ICorpIMPDService
    {
        ApiResponse<MaterialModel> GetCorpIMPDMaterialData(int MaterialTypeId);
        BaseApiResponse InsertOrUpdateCorpIMPD(CorpIMPDModel model);
        ApiResponse<CorpIMPDModel> GetCorpIMPDDetail(int CoverPageId);
    }
}
