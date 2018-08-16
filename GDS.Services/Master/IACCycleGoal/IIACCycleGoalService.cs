using GDS.Entities.Master.IACCycleGoalModel;


namespace GDS.Services.Master.IACCycleGoal
{
    using Common;
    using Entities;
    using Entities.Master;

    public interface IIACCycleGoalService
    {
        ApiResponse<TonnageRangeModel> GetTonnageRange();

        ApiResponse<IACCycleGoalModel> GetIACCycleGoalList();

        ApiResponse<IACCycleGoalModel> GetIACCycleGoalDetail(int IACCycleGoalId);

        BaseApiResponse AddOrUpdateIACCycleGoalData(int UserId, IACCycleGoalModel model);

        BaseApiResponse DeleteIACCycleGoalData(int IACCycleGoalId);
    }
}
