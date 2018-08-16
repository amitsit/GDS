namespace GDS.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    public class AccountController : Controller
    {
        [Route("Unauthorize")]
        public ActionResult Unauthorize()
        {
            return View();
        }

        [Authorize]
        private UserLoginInfo GetWindowsLoginInfo()
        {
            if (!Request.LogonUserIdentity.IsAuthenticated)
            {
                return null;
            }

            return new UserLoginInfo("Windows", Request.LogonUserIdentity.User.ToString());
        }      
    }
}