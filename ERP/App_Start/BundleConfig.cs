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
                        "~/Scripts/angular-animate.min.js",
                        "~/Scripts/angular-aria.min.js",
                        "~/Scripts/angular-material.min.js",
                        "~/AdminContent/js/bootstrap.min.js",
                        "~/AdminContent/js/plugins/metismenu/jquery.metisMenu.js",
                        "~/AdminContent/js/functions.js",
                        "~/AdminContent/js/plugins/datatables/jquery.dataTables.min.js",
                        "~/AdminContent/js/plugins/datatables/dataTables.bootstrap.min.js",
                        "~/AdminContent/js/jquery.validate.min.js",
                        "~/Scripts/toastr.min.js",
                        "~/AdminContent/js/plugins/wizard/jquery.bootstrap.wizard.min.js"

                        ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryLib").Include(
                        "~/Content/js/jquery.min.js",
                        "~/Content/js/bootstrap.min.js",
                        "~/Content/js/jquery.flexslider-min.js",
                        "~/Content/js/jquery.fancybox.pack.js",
                        "~/Content/js/modernizr.js",
                        "~/Content/js/main.js",
                        "~/Content/js/jquery.contact.js",
                        "~/Content/js/jquery.devrama.slider.min-0.9.4.js"
                        ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryLibLogin").Include(
                "~/Content/js/jquery.min.js",
                "~/Content/js/bootstrap.min.js"
                ));
            bundles.Add(new StyleBundle("~/Content/cssLogin").Include(

                "~/Content/css/bootstrap.min.css",
                "~/Content/css/main.css"
                ));


            bundles.Add(new StyleBundle("~/Content1/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/flexslider.css",
                      "~/Content/css/jquery.fancybox.css",
                      "~/Content/css/main.css",
                      "~/Content/css/responsive.css",
                      "~/Content/css/font-icon.css",
                      "~/Content/css/animate.min.css",
                      "~/Content/css/font-awesome.min.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/cssAdmin").Include(
                      "~/AdminContent/css/entypo.css",
                      "~/AdminContent/css/font-awesome.min.css",
                      "~/AdminContent/css/bootstrap.min.css",
                      "~/AdminContent/css/mouldifi-core.css",
                      "~/AdminContent/css/mouldifi-forms.css",
                      "~/AdminContent/css/plugins/datatbles/jquery.dataTables.css",
                      "~/AdminContent/css/Custom.css",
                      "~/content/toastr.css",
                      "~/content/angular-material.min.css"
                      ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
