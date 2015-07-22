using System.Web;
using System.Web.Optimization;

namespace CrmWeb
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Jquery基本代码
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/js/jquery.min.js"));

            // JqueryUI代码
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));
            // Jquery验证代码
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));


            // 暂时不需要，使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/js/bootstrap.min.js",
                      "~/js/raphael-min.js",
                      "~/js/plugins/morris/morris.min.js",
                      "~/js/plugins/sparkline/jquery.sparkline.min.js",
                      "~/js/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                      "~/js/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                      "~/js/plugins/fullcalendar/fullcalendar.min.js",
                      "~/js/plugins/jqueryKnob/jquery.knob.js",
                      "~/js/plugins/daterangepicker/daterangepicker.js",
                      "~/js/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                      "~/js/plugins/iCheck/icheck.min.js",
                      "~/js/AdminLTE/app.js",
                      "~/js/AdminLTE/dashboard.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/font-awesome.min.css",
                      "~/css/ionicons.min.css",
                      "~/css/morris/morris.css",
                      "~/css/jvectormap/jquery-jvectormap-1.2.2.css",
                      "~/css/fullcalendar/fullcalendar.css",
                      "~/css/daterangepicker/daterangepicker-bs3.css",
                      "~/css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                      "~/css/AdminLTE.css"));


        }
    }
}
