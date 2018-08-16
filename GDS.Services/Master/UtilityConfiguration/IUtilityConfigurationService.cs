using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GDS.Entities.Master;
using GDS.Common;

namespace GDS.Services.Master.UtilityConfiguration
{
   public interface IUtilityConfigurationService
    {
        ApiResponse<UtilityConfigurationModel> GetPlantConfigurationDetail(int PlantId);
        BaseApiResponse UpdatePlantConfiguration( int UserId, List<UtilityConfigurationModel> UtilityPlantDataCollection);
    }
}
