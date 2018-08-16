using GDS.Common;
using GDS.Entities.SMOM.PartAndMoldTemperatureMapping;

namespace GDS.Services.SMOM.PartAndMoldTemperatureMapping
{
    public interface IPartAndMoldTemperatureMappingService
    {
        //ApiResponse<PartAndMoldTemperatureMapModel> GetPartAndMoldTemperatureMap(int coverPageId, short lengthUnitId);
        ApiResponse<PartAndMoldTemperatureMapModel> GetPartAndMoldTemperatureMap(int coverPageId, short lengthUnitId, bool IsDOEData);

        ApiResponse<PartAndMoldTemperatureModel> GetPartAndMoldTemperature(int PartAndMoldTemperatureMapId);

        BaseApiResponse AddOrUpdatePartAndMoldTemperatureMapData(int UserId, short lengthUnitId,int coverPageId, PartAndMoldTemperatureMapModel PartAndMoldObj);

        BaseApiResponse DeletePartAndMoldTemperatureMapData(int PartAndMoldTemperatureMapId);

        BaseApiResponse AddOrUpdatePartMoldTemperatureMapData(int LoggedInUserId, short lengthUnitId, PartAndMoldTemperatureMapModel PartAndMoldObj);
    }
}
