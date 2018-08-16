namespace GDS.Web.Controllers
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web;
    using System.Web.Mvc; 

    public class HomeController : BaseController
    {
        [CustomAuthorization]
        public ActionResult Index()
        {
            if (ProjectSession.LoggedInUserDetail==null || !(ProjectSession.LoggedInUserDetail.UserId > 0))
            {
                return  RedirectToAction("Unauthorize", "account", new { strResp = string.Empty });
            }

            return View();
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

        [HttpPost]
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