using System.Web;
using System.Web.Optimization;

namespace ICM.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                         "~/Scripts/jquery.js",
                          "~/Scripts/bootstrap.js",
                           "~/Scripts/metisMenu.js",
                           "~/Scripts/dropdown.js",
                           "~/Scripts/collapse.js",
                            "~/Scripts/respond.js",
                            "~/Scripts/sb-admin-2.js"
                          ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                        "~/Scripts/morris.js",
                            "~/Scripts/morris-data.js",
                            "~/Scripts/raphael.js"));

            bundles.Add(new ScriptBundle("~/bundles/Highchart").Include("~/Scripts/Highcharts-4.0.1/js/highcharts.js"));
          
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/site.css",
                      "~/Content/font-awesome.css",
                      "~/Content/sb-admin-2.css",
                       "~/Content/metisMenu.css",
                       "~/Content/timeline.css",
                       "~/Content/morris.css",
                       "~/Content/ICM.css"
                        ));

            BundleTable.EnableOptimizations = true;
        }
    }
}
