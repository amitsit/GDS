namespace GDS.Web
{
    using System;
    using System.IO.Compression;
    using System.Net;
    using System.Web;
    using System.Web.Optimization;

    #region GZip Compression

    /// <summary>
    /// Class GZipBundle.
    /// </summary>
    public class GZipBundle : Bundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GZipBundle" /> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path used to reference the <see cref="T:System.Web.Optimization.Bundle" /> from within a view or Web page.</param>
        /// <param name="transforms">A list of <see cref="T:System.Web.Optimization.IBundleTransform" /> objects which process the contents of the bundle in the order which they are added.</param>
        public GZipBundle(string virtualPath, params IBundleTransform[] transforms)
            : base(virtualPath, null, transforms)
        {
        }

        /// <summary>
        /// GS the zip encode page.
        /// Sets up the current page or handler to use GZip through a Response.Filter.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        public static void GZipEncodePage(HttpContextBase httpContext)
        {
            if (null != httpContext && null != httpContext.Request && null != httpContext.Response && (null == httpContext.Response.Filter || !(httpContext.Response.Filter is GZipStream || httpContext.Response.Filter is DeflateStream)))
            {
                // Is GZip supported?
                string acceptEncoding = httpContext.Request.Headers["Accept-Encoding"];
                if (null != acceptEncoding && acceptEncoding.IndexOf(DecompressionMethods.GZip.ToString(), StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    httpContext.Response.Filter = new GZipStream(httpContext.Response.Filter, CompressionMode.Compress);
                    httpContext.Response.AddHeader("Content-Encoding", DecompressionMethods.GZip.ToString().ToLowerInvariant());
                }
                else if (null != acceptEncoding && acceptEncoding.IndexOf(DecompressionMethods.Deflate.ToString(), StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    httpContext.Response.Filter = new DeflateStream(httpContext.Response.Filter, CompressionMode.Compress);
                    httpContext.Response.AddHeader("Content-Encoding", DecompressionMethods.Deflate.ToString().ToLowerInvariant());
                }

                // Allow proxy servers to cache encoded and decoded versions separately
                httpContext.Response.AppendHeader("Vary", "Content-Encoding");
            }
        }

        /// <summary>
        /// Overrides this to implement own caching logic.
        /// </summary>
        /// <param name="context">The bundle context.</param>
        /// <returns>A bundle response.</returns>
        public override BundleResponse CacheLookup(BundleContext context)
        {
            if (null != context)
            {
                GZipEncodePage(context.HttpContext);
            }

            return base.CacheLookup(context);
        }
    }

    /// <summary>
    /// Class GZipStyleBundle. This class cannot be inherited.
    /// Represents a bundle that does CSS minification and GZip compression.
    /// </summary>
    public sealed class GZipStyleBundle : GZipBundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GZipStyleBundle"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        /// <param name="transforms">The transforms.</param>
        public GZipStyleBundle(string virtualPath, params IBundleTransform[] transforms)
            : base(virtualPath, transforms)
        {
        }
    }

    /// <summary>
    /// Class GZipScriptBundle. This class cannot be inherited.
    /// Represents a bundle that does JS minification and GZip compression.
    /// </summary>
    public sealed class GZipScriptBundle : GZipBundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GZipScriptBundle"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        /// <param name="transforms">The transforms.</param>
        public GZipScriptBundle(string virtualPath, params IBundleTransform[] transforms)
            : base(virtualPath, transforms)
        {
            this.ConcatenationToken = ";" + Environment.NewLine;
        }
    }

    #endregion

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        /// <summary>
        /// Registers the bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.11.3.min.js",
                        "~/Scripts/jquery-ui.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/exportHTMLTABLEtoPDF").Include(
                      "~/Scripts/jspdf.debug.js"
                       ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            //// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js"
                      , "~/Scripts/bootstrap-modalmanager.js"
                      , "~/Scripts/bootstrap-modal.js"
                      , "~/Scripts/bootstrap-datepicker.js"
                      , "~/Scripts/bootstrap-timepicker.min.js"
                      , "~/Scripts/jquery.bootstrap-duallistbox.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.ar.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.az.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.bg.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.bs.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.ca.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.cs.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.cy.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.da.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.de.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.el.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.en-GB.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.eo.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.es.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.et.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.eu.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.fa.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.fi.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.fo.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.fr-CH.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.fr.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.gl.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.he.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.hr.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.hu.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.hy.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.id.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.is.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.it-CH.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.it.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.ja.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.ka.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.kh.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.kk.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.ko.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.kr.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.lt.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.lv.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.me.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.mk.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.mn.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.ms.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.nb.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.nl-BE.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.nl.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.no.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.pl.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.pt-BR.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.pt.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.rs.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.ru.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.sk.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.sl.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.sq.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.sr-latin.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.sr.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.sv.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.sw.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.th.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.tr.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.uk.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.vi.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.zh-CN.js"
                      //, "~/Scripts/locales/bootstrap-datepicker.zh-TW.js"
                      , "~/Scripts/bootbox.js"
                      , "~/Scripts/percircle.js"
                      , "~/Scripts/lightbox.min.js"
                      ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Content/css/bootstrap.css"
                      , "~/Content/css/font-awesome.min.css"
                      , "~/Content/css/textAngular.css"
                      , "~/Content/css/bootstrap-duallistbox.css"
                      , "~/Content/css/jquery.dataTables.min.css"
                      , "~/Content/css/bootstrap-datepicker.min.css"
                      , "~/Content/css/bootstrap-timepicker.min.css"
                      , "~/Content/css/toastr.css"
                      , "~/Content/css/site.css"
                      , "~/Content/css/rzslider.css"
                      , "~/Content/css/nav.css"
                      , "~/Content/css/Custom.css"
                      , "~/Content/css/treeGrid.css"
                      , "~/Content/css/angular.treeview.css"
                      , "~/Content/css/jquery-ui.min.css"
                      , "~/Content/css/angular-ui-switch.min.css"
                      , "~/Content/css/jquery.mCustomScrollbar.min.css"
                      , "~/Content/css/percircle.css"
                      , "~/Content/css/lightbox.min.css"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-filter.min.js",
                      "~/Scripts/angular-animate.min.js",
                      // "~/Scripts/angular-dragdrop.min.js",
                      "~/Scripts/angular-ui-router.min.js",
                      "~/Scripts/angular-local-storage.js",
                      "~/Scripts/angular-sanitize.js",
                      "~/Scripts/angular-datatables.min.js",
                      "~/Scripts/angucomplete-alt.min.js",
                      "~/Scripts/angular-ui-switch.min.js",
                      "~/Scripts/angular-translate.min.js",
                      "~/Scripts/angular-translate-loader-static-files.min.js",
                      "~/Scripts/loadash.min.js")
                      );

            //var ckeditorBundle = new Bundle("~/bundles/ckeditor");
            //ckeditorBundle.Include("~/Content/ckeditor/ckeditor.js");
            //ckeditorBundle.Include("~/Content/ckeditor/adapters/jquery.js");
            //bundles.Add(ckeditorBundle);


            var appConfigBundle = new Bundle("~/bundles/appConfig");

            appConfigBundle.Include("~/Scripts/angular.treeview.js");
            appConfigBundle.Include("~/Scripts/tree-grid-directive.js");

            appConfigBundle.Include("~/Scripts/ng-ckeditor.js");

            appConfigBundle.Include("~/Scripts/jquery.dataTables.min.js");
            appConfigBundle.Include("~/Scripts/dataTables.tableTools.js");
            appConfigBundle.Include("~/Scripts/dataTables.fixedColumns.min.js");
            appConfigBundle.Include("~/Scripts/jquery.dataTables.rowReordering.js");
            appConfigBundle.Include("~/Scripts/jquery.freezeheader.js");
            appConfigBundle.Include("~/Scripts/dataTables.rowsGroup.js");

            appConfigBundle.Include("~/Scripts/ng-file-upload.min.js");
            appConfigBundle.Include("~/Scripts/ng-file-upload-shim.min.js");
            appConfigBundle.Include("~/Scripts/textAngular-rangy.min.js");
            appConfigBundle.Include("~/Scripts/textAngular-sanitize.js");
            appConfigBundle.Include("~/Scripts/textAngular.min.js");
            appConfigBundle.Include("~/Scripts/rzslider.js");

            appConfigBundle.Include("~/Scripts/jquery.responsiveTabs.js");
            appConfigBundle.Include("~/Scripts/menuscript.js");
            appConfigBundle.Include("~/Scripts/toastr.js");
            appConfigBundle.Include("~/Scripts/Chart.min.js");

            appConfigBundle.Include("~/JS/dirPagination.js");
            appConfigBundle.Include("~/JS/appConfiguration.js");
            appConfigBundle.Include("~/JS/Common.js");
            appConfigBundle.Include("~/JS/Enums.js");
            appConfigBundle.Include("~/Scripts/bsDuallistbox.js");

            //appConfigBundle.Include("~/Content/ckeditor/ckeditor.js");
            //appConfigBundle.Include("~/Content/ckeditor/adapters/jquery.js");

            appConfigBundle.IncludeDirectory("~/JS/Directives", "*.js", false);
            appConfigBundle.IncludeDirectory("~/JS/Factory", "*.js", false);
            appConfigBundle.IncludeDirectory("~/JS/Filters", "*.js", false);




            bundles.Add(appConfigBundle);



            //  appConfigBundle.Include("~/Scripts/ui-bootstrap-tpls.js");

            var controllerBundle = new Bundle("~/bundles/ControllerAndServices");
            controllerBundle.IncludeDirectory("~/JS/Home", "*.js", true);
            controllerBundle.IncludeDirectory("~/JS/Master", "*.js", true);
            controllerBundle.IncludeDirectory("~/JS/Processes", "*.js", true);        
            controllerBundle.IncludeDirectory("~/JS/SubProcess", "*.js", true);
            controllerBundle.IncludeDirectory("~/JS/ContactUs", "*.js", true);
            controllerBundle.IncludeDirectory("~/JS/DocumentationLogs", "*.js", true);
            controllerBundle.IncludeDirectory("~/JS/Search", "*.js", true);

            bundles.Add(controllerBundle);
        }
    }
}
