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

            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Select2/Select2.css",
                      "~/Content/Nanogallery2/nanogallery2.min.css",
                      "~/Content/Dropzone/basic.css",
                      "~/Content/Dropzone/dropzone.css"
                      ));
            // Login
            bundles.Add(new StyleBundle("~/Content/login").Include(
                      "~/Content/login.css"));

            // Dropzone
            bundles.Add(new ScriptBundle("~/bundles/dropzonescripts").Include(
                     "~/Scripts/Dropzone/dropzone.js"));
            bundles.Add(new ScriptBundle("~/bundles/dropzoneconfig").Include(
                     "~/Scripts/dropzone-configuration.js"));                       

            // Nanogallery2
            bundles.Add(new ScriptBundle("~/bundles/nanogallery").Include(
                     "~/Scripts/Nanogallery2/jquery.nanogallery2.js"));

            // SweetAlert2
            bundles.Add(new ScriptBundle("~/bundles/swal").Include(
                     "~/Scripts/SweetAlert2/SweetAlert2.js"));

            // Select2
            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                     "~/Scripts/Select2/Select2.js"));

            // Caption (personal scripts)
            bundles.Add(new ScriptBundle("~/bundles/caption").Include(
                     "~/Scripts/Caption.js"));
        }
    }
}
