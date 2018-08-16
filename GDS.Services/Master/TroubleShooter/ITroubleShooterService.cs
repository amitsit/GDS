using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GDS.Services.Master.TroubleShooter
{
    public interface ITroubleShooterService
    {
        ApiResponse<TroubleShooterModel> GetTroubleShooterList(long TroubleShooterId);
        ApiResponse<TroubleShooterModel> GetTroubleShooterDetail(long TroubleShooterId);
        BaseApiResponse AddOrUpdateTroubleShooter(TroubleShooterModel model);
        BaseApiResponse DeleteTroubleShooter(long TroubleShooterId);
        ApiResponse<TroubleShooterModel> GetPageHelp(string PageName,string LanguageCd);
        ApiResponse<TroubleShooterModel> GetPageHelpContent(long TroubleShooterId);
        ApiResponse<TroubleShooterModel> GetPageHelpDetail(string PageName, string LanguageCd);
    }
}
