using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Apadana.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bottom-panel").Include(
                "~/theme-admin/js/jquery-2.1.1.js",
                "~/theme-admin/js/bootstrap.min.js",
                "~/theme-admin/js/plugins/metisMenu/jquery.metisMenu.js",
                "~/theme-admin/js/plugins/slimscroll/jquery.slimscroll.min.js",
                "~/theme-admin/js/plugins/flot/jquery.flot.js",
                "~/theme-admin/js/plugins/flot/jquery.flot.tooltip.min.js",
                "~/theme-admin/js/plugins/flot/jquery.flot.spline.js",
                "~/theme-admin/js/plugins/flot/jquery.flot.resize.js",
                "~/theme-admin/js/plugins/flot/jquery.flot.pie.js",
                "~/theme-admin/js/plugins/peity/jquery.peity.min.js",
                "~/theme-admin/js/demo/peity-demo.js",
                "~/theme-admin/js/rada.js",
                "~/theme-admin/js/plugins/pace/pace.min.js",
                "~/theme-admin/js/plugins/jquery-ui/jquery-ui.min.js",
                "~/theme-admin/js/plugins/gritter/jquery.gritter.min.js",
                "~/theme-admin/js/plugins/sparkline/jquery.sparkline.min.js",
                "~/theme-admin/js/demo/sparkline-demo.js",
                "~/theme-admin/js/plugins/chartJs/Chart.min.js",
                "~/theme-admin/js/plugins/toastr/toastr.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/theme-admin/js/plugins/sweetalert/sweetalert.min.js",
                "~/AppScripts/app.js"));

            

            bundles.Add(new StyleBundle("~/bundles/modernizr").Include());
                //"~/Content/site/...",
                //"~/content/css{version}.css",
                //"~/content/jquery.unobtrusive*"));
        }
    }
}