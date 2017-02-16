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
            bundles.Add(new ScriptBundle("~/bundles/top-panel").Include(
                "~/Scripts/..."));

            bundles.Add(new ScriptBundle("~/bundles/bottom-panel").Include(
                ));

            bundles.Add(new StyleBundle("~/bundles/modernizr").Include(
                "~/Content/site/...",
                "~/content/css{version}.css",
                "~/content/jquery.unobtrusive*"));
        }
    }
}