using GDS.Common;
using GDS.Entities.STMP.MROData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.STMP.MROData
{
    public interface IMRODataService
    {
        ApiResponse<MRODataModel> GetMROData(int PlantId);

        BaseApiResponse SaveMROData(MRODataModel model);
    }
}
