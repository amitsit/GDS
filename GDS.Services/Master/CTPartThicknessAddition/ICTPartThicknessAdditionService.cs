using GDS.Common;
using GDS.Entities.Master;
using GDS.Entities.STMP.InputData;

namespace GDS.Services.Master.CTPartThicknessAddition
{
    public interface ICTPartThicknessAdditionService
    {
        /// <summary>
        ///  To get the CTPartThicknessAddition list or particular details
        /// </summary>
        /// <param name="cTPartThicknessAdditionId"></param>
        /// <returns></returns>
        ApiResponse<CTPartThicknessAdditionModel> GetCTPartThicknessAddition(long? CTPartThicknessAdditionId);

        /// <summary>
        /// To Add or Update CTPartThicknessAddition details
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        BaseApiResponse AddOrUpdateCTPartThicknessAdditionData(int UserId, CTPartThicknessAdditionModel model);


        /// <summary>
        /// To Delete CTPartThicknessAddition Details
        /// </summary>
        /// <param name="cTPartThicknessAdditionId"></param>
        /// <returns></returns>
        BaseApiResponse DeleteCTPartThicknessAdditionData(long CTPartThicknessAdditionId);
    }
}
