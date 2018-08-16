namespace GDS.Services.Master.Material
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common;
    using Entities.Master;

    public interface IMaterialService
    {
        ApiResponse<MaterialModel> GetMaterialList(int MaterialId = 0);

    }
}
