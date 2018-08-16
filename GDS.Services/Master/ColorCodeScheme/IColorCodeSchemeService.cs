using GDS.Common;
using GDS.Entities.Master;
using GDS.Entities.SMOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.ColorCodeScheme
{
    public interface IColorCodeSchemeService
    {
        ApiResponse<ColorCodeSchemeModel> GetColorCodeSchemeList(Int16 lengthUnitId, Int16 pressureUnitId, TroubleShooterPostModel Model);
    }
}
