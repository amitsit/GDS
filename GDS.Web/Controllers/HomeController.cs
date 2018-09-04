


namespace GDS.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web;
    using System.Web.Mvc;
    using Common;
    using Entities.Master;
    using GDS.Entities;

    public class HomeController:Controller
    {

        public ActionResult Index()
        {
            if (ProjectSession.LoggedInUserDetail == null || !(ProjectSession.LoggedInUserDetail.UserId > 0))
            {
                ProjectSession.LoggedInUserDetail = new Entities.LoggedInUserDetail(); 
                ProjectSession.LoggedInUserDetail.RolesRightsPermissions = new System.Collections.Generic.List<Entities.Master.RoleRightsPermissionModel>();
            }

            return this.View();
        }

        [Route("Login")]
        public JsonResult Login(string Id,string Password)
        {
            int? UserId = 0;

            ProjectSession.LoggedInUserDetail = GetUserDetailByIdAndPassword(Id, Password);

            if (ProjectSession.LoggedInUserDetail != null && ProjectSession.LoggedInUserDetail.UserId > 0)
            {
                UserId = ProjectSession.LoggedInUserDetail.UserId;
                ProjectSession.LoggedInUserDetail.LoginUserUniqueKey = Guid.NewGuid().ToString();
            }

            if (UserId > 0)
            {
                // Assign Right
                var tblRoleRights = this.GetRoleRights();
                if (tblRoleRights != null)
                {
                    ProjectSession.LoggedInUserDetail.RolesRightsPermissions = tblRoleRights;
                }
            }
            else
            {
                // Assign Right 
                var tblRoleRights = this.GetRoleRights();
                if (tblRoleRights != null)
                {
                    ProjectSession.LoggedInUserDetail.RolesRightsPermissions = tblRoleRights;
                }
            }

            //if (ProjectSession.LoggedInUserDetail == null || !(ProjectSession.LoggedInUserDetail.UserId > 0))
            //{
            //   return this.RedirectToAction("Index", "Home", new { strResp = string.Empty });
            //}
            return Json(ProjectSession.LoggedInUserDetail, JsonRequestBehavior.AllowGet);
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

public LoggedInUserDetail GetUserDetailByIdAndPassword(string id,string password)
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
            var responseTask = client.GetAsync("LoginUser?Id=" + id + "&Password="+ password);
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

        [HttpGet]
        [Route("SignOut")]
        public void SignOut()
        {
            ProjectSession.LoggedInUserDetail = new LoggedInUserDetail(); 
        }

        [HttpGet]
        [Route("AccessDenied")]
        public ActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [Route("incompatiblebrowser")]
        public ActionResult incompatiblebrowser()
        {

            return View();
        }

        [Route("CheckVersionNumber")]
        [AllowAnonymous]
        public string CheckVersionNumber()
        {
            string str = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ApplicationVersion"]);
            return str;
        }

        [System.Web.Mvc.HttpPost]
        [Route("UploadPartMoldTemperatureImage")]
        public string UploadPartMoldTemperatureImage(string Name,string MoldNumber, bool IsDOEData = false)
        {
            string ImagePath = "";
            string folderPath;
            if (IsDOEData == true)
            {
                folderPath = "DataImages/DOEImages/";
                if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "DataImages/DOEImages"))
                {
                    Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "DataImages/DOEImages");
                }
            }
            else
            {
                folderPath = "DataImages/PartMoldTempratureImages/" + MoldNumber+"/";
                if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "DataImages/PartMoldTempratureImages/" + MoldNumber + "/"))
                {
                    Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "DataImages/PartMoldTempratureImages/" + MoldNumber + "/");
                }
            }




            //if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "PartMoldTempratureImages"))
            //{
            //    Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "PartMoldTempratureImages");
            //}

            HttpPostedFile httpPostedFile = null;
            if (System.Web.HttpContext.Current.Request.Files!=null)
            {
                // Get the uploaded image from the Files collection
                httpPostedFile = System.Web.HttpContext.Current.Request.Files[0];
                httpPostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + folderPath + Name);
                ImagePath = "/" + folderPath + Name;
                //response.Message.Add("IACBI.API/" + folderPath + Name);
                //response.Success = true;
            }



            return ImagePath;
        }


    }
}