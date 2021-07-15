using System.Web;
using System.Web.Optimization;

namespace WebInterna
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

            bundles.Add(new ScriptBundle("~/bundles/agregarZona").Include(
                        "~/Scripts/mapsApi/agregarZona.js"));

            bundles.Add(new ScriptBundle("~/bundles/previsualizarZona").Include(
                        "~/Scripts/mapsApi/previsualizarZona.js"));

            bundles.Add(new ScriptBundle("~/bundles/primerReporte").Include(
                        "~/Scripts/primerReporte.js"));

            bundles.Add(new ScriptBundle("~/bundles/quintoReporte").Include(
                        "~/Scripts/quintoReporte.js"));

            bundles.Add(new ScriptBundle("~/bundles/reclamos").Include(
                        "~/Scripts/listarReclamos.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/validationStyle.css",
                      "~/Content/css/mapsApi.css",
                      "~/Content/css/generalPage.css"));
        }
    }
}
