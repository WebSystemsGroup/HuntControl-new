using System.Web.Optimization;

namespace HuntControl.WebUI
{
    public class BundleConfig
    {
        // Дополнительные сведения о Bundling см. по адресу http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs")
                        .Include("~/Scripts/bootstrap.*")
                        .Include("~/Scripts/moment-with-locales.min.js")
                        .Include("~/Content/plugins/bootstrap-inputmask/dist/jquery.inputmask.bundle.*")
                        .Include("~/Content/plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.*")
                        .Include("~/Content/plugins/bootstrap-datepicker/dist/locales/bootstrap-datepicker.ru.*"));

            bundles.Add(new ScriptBundle("~/bundles/javaScripts")
                        .Include("~/Scripts/admin/admin-layout.js")
                        .Include("~/Content/plugins/sweetalert/dist/js/sweetalert.*")
                        .Include("~/Content/plugins/sweet-alert2/js/sweetalert2.*")
                        .Include("~/Content/plugins/custombox/dist/custombox.*")
                        .Include("~/Content/plugins/custombox/dist/legacy.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-{version}.js"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/styles")
                        .Include("~/Content/plugins/sweetalert/dist/css/sweetalert.*")
                        .Include("~/Content/plugins/sweet-alert2/css/sweetalert2.*")
                        .Include("~/Content/plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.*")
                        .Include("~/Content/plugins/select2/css/select2.*")
                        .Include("~/Content/plugins/bootstrap-select/dist/css/bootstrap-select.*")
                        .Include("~/Content/plugins/custombox/dist/custombox.*")
                        .Include("~/Content/plugins/summernote/dist/summernote.css")
                        .Include("~/Content/css/bootstrap.*"));
        }
    }
}