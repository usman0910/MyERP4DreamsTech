using System.Web;
using System.Web.Optimization;

namespace ERP
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryLibAdmin").Include(
                        "~/AdminContent/js/jquery.min.js",
                        "~/AdminContent/js/bootstrap.min.js",
                        "~/AdminContent/js/plugins/metismenu/jquery.metisMenu.js",
                        "~/AdminContent/js/plugins/blockui-master/jquery-ui.js",
                        "~/AdminContent/js/plugins/blockui-master/jquery.blockUI.js",
                        "~/AdminContent/js/functions.js"
                        ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryLib").Include(
                        "~/Content/js/jquery.min.js",
                        "~/Content/js/bootstrap.min.js",
                        "~/Content/js/jquery.flexslider-min.js",
                        "~/Content/js/jquery.fancybox.pack.js",
                        "~/Content/js/bootstrap.min.js",
                        "~/Content/js/bootstrap.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/cssAdmin").Include(
                      "~/AdminContent/css/entypo.css",
                      "~/AdminContent/css/font-awesome.min.css",
                      "~/AdminContent/css/bootstrap.min.css",
                      "~/AdminContent/css/mouldifi-core.css",
                      "~/AdminContent/css/mouldifi-forms.css"
                      ));
        }
    }
}
