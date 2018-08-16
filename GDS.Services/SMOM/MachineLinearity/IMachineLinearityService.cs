using System;
using GDS.Common;
using GDS.Entities.SMOM.MachineLinearity;

namespace GDS.Services.SMOM.MachineLinearity
{
    public interface IMachineLinearityService
    {
        ApiResponse<MachineLinearityModel> GetMachineConfigurationDetails(int plantId, int? plantEquipmentListId, Int16 lengthUnitId, Int16 pressureUnitId,long coverPageId,bool getAllData = false);
        BaseApiResponse InsertUpdateMachineLinearity(Int16 lengthUnitId, MachineLinearityModel model);
    }
}
