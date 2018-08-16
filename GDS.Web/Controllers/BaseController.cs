using System.DirectoryServices;

namespace GDS.Web.Controllers
{
    using System;
    using System.DirectoryServices.Protocols;
    using System.Net;
    using System.Web.Mvc;
    using System.Linq;
    using System.Web.Mvc.Filters;
    using System.Web.Routing;
    using Entities;
    using Microsoft.AspNet.Identity;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;

    public class BaseController : Controller
    {
        /// <summary>
        /// Called when authorization occurs.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            DataTable DT = new DataTable();
            if (ProjectSession.LoggedInUserDetail == null)
            {
                // using (var context = new ApplicationDbContext())
                // {
                if (string.IsNullOrEmpty(User.Identity.GetUserId()) && User.Identity.IsAuthenticated)
                {
                    // var isValidUser = ValidateUser();
                    // GetUserDetails();
                    // ApplicationUser user = context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                }
                else
                {                   
                    filterContext.Result = RedirectToRoute("Unauthorize");//RedirectToAction("Unauthorize", "account", new { strResp = string.Empty });//new RedirectToRouteResult("Unauthorize", new RouteValueDictionary { { "action", "Unauthorize" }, { "controller", "account" } });
                }

            }
        }

        ///// <summary>
        ///// Initializes data that might not be available when the constructor is called.
        ///// </summary>
        ///// <param name="requestContext">The HTTP context and route data.</param>
        // protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        // {
        //    base.Initialize(requestContext);
        // }

        // public static void GetUserDetails()
        // {
        //    DirectoryEntry entry = new DirectoryEntry("LDAP://sitdomain.net", Environment.UserName.Trim(), "admin@123");
        //    DirectorySearcher dSearch = new DirectorySearcher(entry);

        // // dSearch.Filter = "(&(objectClass=user)(l=" + Environment.UserName + "))";

        // // get all entries from the active directory.
        //    // Last Name, name, initial, homepostaladdress, title, company etc..
        //    foreach (SearchResult sResultSet in dSearch.FindAll())
        //    {
        //        // Login Name
        //        var loginName = GetProperty(sResultSet, "cn");

        // // First Name
        //        var givenName = GetProperty(sResultSet, "givenName");

        // // Middle Initials
        //        var middleName = GetProperty(sResultSet, "initials");

        // // Last Name
        //        var lastName = GetProperty(sResultSet, "sn");

        // // email address
        //        var email = GetProperty(sResultSet, "mail");

        // // Address
        //        var tempAddress = GetProperty(sResultSet, "homePostalAddress");

        // // title
        //        var title = GetProperty(sResultSet, "title");

        // // company
        //        var company = GetProperty(sResultSet, "company");

        // // state
        //        var state = GetProperty(sResultSet, "st");

        // // city
        //        var city = GetProperty(sResultSet, "l");

        // // country
        //        var country = GetProperty(sResultSet, "co");

        // // postal code
        //        var postalCode = GetProperty(sResultSet, "postalCode");

        // // telephonenumber
        //        var telephonenumber = GetProperty(sResultSet, "telephoneNumber");

        // // otherTelephone
        //        var otherTelephone = GetProperty(sResultSet, "otherTelephone");

        // // email
        //        var eamil = GetProperty(sResultSet, "extensionAttribute9");
        //    }
        // }

        // public static string GetProperty(SearchResult searchResult, string propertyName)
        // {
        //    return
        //        searchResult.Properties.Contains(propertyName)
        //            ? searchResult.Properties[propertyName][0].ToString()
        //            : string.Empty;
        // }

        public static bool ValidateUser()
        {
            bool validation;
            try
            {
                LdapConnection lcon = new LdapConnection(new LdapDirectoryIdentifier(@"sitdomain.net", false, false));
                NetworkCredential nc = new NetworkCredential(Environment.UserName,
                                       "admin@123", Environment.UserDomainName);
                lcon.Credential = nc;
                lcon.AuthType = AuthType.Negotiate;

                // user has authenticated at this point,
                // as the credentials were used to login to the dc.
                lcon.Bind(nc);
                validation = true;
            }
            catch (LdapException)
            {
                validation = false;
            }

            return validation;
        }

    }
}