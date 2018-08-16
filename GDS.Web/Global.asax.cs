namespace GDS.Web
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhanded error occurs
            // Get the exception object.
            Exception exc = Server.GetLastError();

            // Log the exception and notify system operators
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log.Error(HttpContext.Current.Request.Url, exc);

            // Clear the error from the server
            Server.ClearError();
        }

        /// <summary>
        /// Use Application End Request for Ajax Session Timeout Issues.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_EndRequest(object sender, EventArgs e)

        {
            // If we have Session Contact Item is False then we will set Status Code=401. so, we will handle this Ajax Request
            // Under Common.Js - > RedirectToLoginOnSessionTimeout Function.
            if (HttpContext.Current.Items["AjaxPermissionDenied"] is bool)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.StatusCode = 401;
            }
        }
    }
}
