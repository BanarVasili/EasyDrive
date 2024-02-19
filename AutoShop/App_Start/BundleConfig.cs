using System.Web;
using System.Web.Optimization;

public class BundleConfig
{
    // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new StyleBundle("~/Content/styles").Include(
            "~/Content/css/bootstrap.min.css",
            "~/Content/css/style.css",
            "~/Content/css/responsive.css",
            "~/Content/css/jquery.mCustomScrollbar.css"
            ));

        // JavaScript bundle
        bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.min.js"));

        bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.validate*"));

        // Use the development version of Modernizr to develop with and learn from. Then, when you're
        // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
        bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"));

        bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            "~/Scripts/bootstrap.js",
            "~/Scripts/bootstrap.bundle.js"));

        // Custom JavaScript files
        bundles.Add(new ScriptBundle("~/bundles/custom").Include(
            "~/Scripts/custom.js",
            "~/Scripts/jquery.mCustomScrollbar.concat.min.js",
            "~/Scripts/popper.min.js",
            "~/Scripts/plugin.js",
            "~/Scripts/slider-setting.js"));

        // Code for the rest of your bundles goes here

        // Set EnableOptimizations to false for debugging. For more information,
        // visit http://go.microsoft.com/fwlink/?LinkId=301862
        BundleTable.EnableOptimizations = true;
    }
}