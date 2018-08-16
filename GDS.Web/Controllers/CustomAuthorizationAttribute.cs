namespace GDS.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using GDS.Entities;
    using GDS.Entities.Master;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net;
    using Common;

    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            DataTable DT = new DataTable();
            //ProjectSession.LoggedInUserDetail = null;
            if (ProjectSession.LoggedInUserDetail == null || !(ProjectSession.LoggedInUserDetail.UserId > 0))
            {
                int? UserId = 0;
                int IsDeveloperMode = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IsDeveloperMode"]);
                if (IsDeveloperMode > 0)
                {
                    ProjectSession.LoggedInUserDetail = GetUserDetailByNetworkUserId(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["NetworkUserId"]));
                }
                else
                {
                    ProjectSession.LoggedInUserDetail = GetUserDetailByNetworkUserId(HttpContext.Current.User.Identity.Name);
                }

                if (ProjectSession.LoggedInUserDetail != null && ProjectSession.LoggedInUserDetail.UserId > 0)
                {
                    UserId = ProjectSession.LoggedInUserDetail.UserId;
                    ProjectSession.LoggedInUserDetail.LoginUserUniqueKey = Guid.NewGuid().ToString();
                }

                if (UserId > 0)
                {
                    //Assign Right 
                    var tblRoleRights = GetRoleRights();
                    if (tblRoleRights != null)
                    {
                        ProjectSession.LoggedInUserDetail.RolesRightsPermissions = tblRoleRights;
                    }

                }

            }
            else
            {
                //Assign Right 
                var tblRoleRights = GetRoleRights();
                if (tblRoleRights != null)
                {
                    ProjectSession.LoggedInUserDetail.RolesRightsPermissions = tblRoleRights;
                }
            }

        }

        public List<RoleRightsPermissionModel> GetRoleRights()
        {
            List<RoleRightsPermissionModel> RoleRights = new List<RoleRightsPermissionModel>();
            var authtHandler = new HttpClientHandler
            {
                Credentials = CredentialCache.DefaultNetworkCredentials
            };

            using (var client = new HttpClient(authtHandler))
            {
                try
                {
                    client.BaseAddress = new Uri(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"]));
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //HTTP GET
                    var responseTask = client.GetAsync("GetLoginUserRoleRights?UserId=" + ProjectSession.LoggedInUserDetail.UserId);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ApiResponse<RoleRightsPermissionModel>>();
                        if (readTask.Result.Data.Count > 0)
                        {
                            RoleRights = readTask.Result.Data.ToList();
                        }
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

            }

            return RoleRights;
        }

        public LoggedInUserDetail GetUserDetailByNetworkUserId(string NetworkUserId)
        {
            LoggedInUserDetail UserDetail = new LoggedInUserDetail();
            var authtHandler = new HttpClientHandler
            {
                Credentials = CredentialCache.DefaultNetworkCredentials
            };

            using (var client = new HttpClient(authtHandler))
            {
                try
                {
                    client.BaseAddress = new Uri(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"]));
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //HTTP GET
                    var responseTask = client.GetAsync("GetLoginUserDetails?networkId=" + NetworkUserId);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ApiResponse<LoggedInUserDetail>>();
                        if (readTask.Result.Data.Count > 0)
                        {
                            UserDetail = readTask.Result.Data[0];
                        }
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

            }

            return UserDetail;
        }

    }
}