using System.Web;
using System.Web.Optimization;

namespace Captions
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Dropzone
            bundles.Add(new ScriptBundle("~/bundles/dropzonescripts").Include(
                     "~/Scripts/Dropzone/dropzone.js"));
            bundles.Add(new StyleBundle("~/Content/dropzonescss").Include(
                     "~/Content/Dropzone/basic.css",
                     "~/Content/Dropzone/dropzone.css"));

            // Login
            bundles.Add(new StyleBundle("~/Content/login").Include(
                      "~/Content/login.css"));

            // Nanogallery
            bundles.Add(new ScriptBundle("~/bundles/nanogallery").Include(
                     "~/Scripts/Nanogallery/jquery.nanogallery.min.js"));
            bundles.Add(new StyleBundle("~/Content/nanogallery").Include(
                    "~/Content/Nanogallery/css/nanogallery.min.css"));

        }
    }
}
