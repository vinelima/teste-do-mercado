using System.Web;
using System.Web.Optimization;

namespace TesteDoMercado
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .IncludeDirectory("~/Content/css", "*.css", true));

            bundles.Add(new ScriptBundle("~/bundles/js/jquery")
                .IncludeDirectory("~/Content/js/jquery", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap")
                .IncludeDirectory("~/Content/js/bootstrap", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                   .Include("~/Content/js/modernizr-*"));
        }
    }
}