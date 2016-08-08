using System.Web;
using System.Web.Optimization;

namespace TestProject.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/Content/assets/js/jquery.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/assets/js/modernizr.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                   "~/Content/assets/js/jquery.min.js",
                   "~/Content/assets/js/bootstrap.min.js",
                   "~/Content/assets/js/soon/plugins.js",
                   "~/Content/assets/js/soon/jquery.themepunch.revolution.min.js",
                   "~/Content/assets/js/soon/custom.js",
                   "~/Scripts/angular.js",
                   "~/Scripts/App/main.js",
                   "~/Scripts/App/modules/services.js",
                   "~/Scripts/App/modules/links.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/css/bootstrap.css",
                      "~/Content/assets/css/soon.css"
                      ));
        }
    }
}
