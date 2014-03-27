using System.Web.Optimization;

namespace J.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region CSS (按名称排序)

            bundles.Add(new StyleBundle("~/Content/all").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/bootstrap-datetimepicker.css",
                "~/Content/font-awesome.css",
                "~/Content/uploadify.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-datetimepicker").Include(
                "~/Content/bootstrap-datetimepicker.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/Content/font-awesome").Include(
                "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/site").Include(
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/uploadify").Include(
                "~/Content/uploadify.css"));

            #endregion

            #region JS (按名称排序)

            bundles.Add(new ScriptBundle("~/Scripts/all").Include(
                "~/Scripts/modernizr-*",
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-datetimepicker.js",
                "~/Scripts/bootstrap-datetimepicker.zh-CN.js",
                "~/Scripts/highcharts.js",
                "~/Scripts/mustache.js",
                "~/Scripts/json2.js",
                "~/Scripts/jquery.base64.js",
                "~/Scripts/sorex-extend.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.messages_zh.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap-datetimepicker").Include(
                "~/Scripts/bootstrap-datetimepicker.js",
                "~/Scripts/bootstrap-datetimepicker.zh-CN.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/highcharts").Include(
                "~/Scripts/highcharts.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery.base64").Include(
                "~/Scripts/jquery.base64.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery.uploadify").Include(
                "~/Scripts/jquery.uploadify.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery.validate").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.messages_zh.js"));

            bundles.Add(new ScriptBundle("~/Scripts/json2").Include(
                "~/Scripts/json2.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/mustache").Include(
                "~/Scripts/mustache.js"));

            bundles.Add(new ScriptBundle("~/Scripts/respond").Include(
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Scripts/sorex-extend").Include(
                "~/Scripts/sorex-extend.js"));

            bundles.Add(new ScriptBundle("~/Scripts/tinymce/js").Include(
                "~/Scripts/tinymce/tinymce.js",
                "~/Scripts/tinymce/jquery.tinymce.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/tinymce/langs/zh_CN").Include(
                "~/Scripts/tinymce/langs/zh_CN.js"));

            #endregion
        }
    }
}