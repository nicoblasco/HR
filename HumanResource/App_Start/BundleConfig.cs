using System.Web;
using System.Web.Optimization;

namespace HumanResource
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/jquery.ba-outside-events.min.js",
                      "~/Scripts/jquery.responsive-tabs.js",
                      "~/Scripts/jquery.flexslider-min.js",
                      "~/Scripts/jquery.fitvids.js",
                      "~/Scripts/jquery-ui-1.10.4.custom.min.js",
                      "~/Scripts/jquery.inview.min.js",
                      "~/Scripts/jquery-ui-1.10.4.custom.min.js",
                      "~/Scripts/owl.carousel.min.js",                      
                      "~/Scripts/scripts.js",
                      "~/Scripts/lobibox.js",
                      "~/Scripts/jquery.dataTables.js",
                      "~/Scripts/dataTables.bootstrap.min.js",
                      "~/Scripts/fnReloadAjax.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/jquery.tagsinput",
                      "~/Content/owl.carousel.css",
                      "~/Content/styles.css",
                      "~/Content/responsive.css",
                      "~/Content/lobibox.css",
                      "~/Content/dataTables.bootstrap.css",
                      "~/Content/lobibox.css",
                      "~/Content/dataTables.responsive.css"));

            bundles.Add(new StyleBundle("~/Content/cssLogin").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/stylesLogin.css"));

        }
    }
}
