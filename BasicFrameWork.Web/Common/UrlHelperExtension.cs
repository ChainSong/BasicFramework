using System.Text;
using BasicFramework.Common;

namespace System.Web.Mvc
{
    public static class UrlHelperExtension
    {
        private const string ScriptBasePath = "~/Scripts/";
        private const string CommonJsBasePath = ScriptBasePath + "Common/";
        private const string FrameworkScriptBasePath = CommonJsBasePath + "Framework/";
        private const string CommonJsPath = "Common.js";
        private const string JQueryBasePath = "jquery-1.7.1.min.js";
        private const string JqueryValidatePath = "jquery.validate.min.js";
        private const string JqueryValidateUnobtrusivePath = "jquery.validate.unobtrusive.min.js";
        private const string CssBasePath = "~/Content/";
        private const string CommonCssBasePath = CssBasePath + "Common/";
        private const string FrameworkCssBasePath = CommonCssBasePath + "Framework/";
        private const string CommonCssPath = "Common.css";
        private const string Json2Path = "json2.js";
        private const string TreeViewCssPath = "TreeView/zTreeStyle.css";
        private const string DateTimeCssPath = "jquery.datetimepicker.css";
        private const string RateStarCssPath = "RateStar/rater-star.css";
        private const string PhoneScriptBasePath = CommonJsBasePath + "Phone/";
        private const string PhoneCssBasePath = CommonCssBasePath + "Phone/";
        private const string jsrenderPath = "jsrender.js";
        private static readonly string[] JqueryMmenuJsPath = { "Phone/jquery.mmenu.min.js"};
        private static readonly string[] JquereyMmenuCssPath = { "Phone/PhoneSite.css", "Phone/jquery.mmenu.css"};
        private static readonly string[] BootStrapCssPath = { "Phone/css/bootstrap-responsive.min.css", "Phone/css/bootstrap.min.css" };
        public static readonly string[] JqueryBase183Path = { "Phone/jquery-1.8.3.min.js" };
        public static readonly string[] BootStrapPath = { "phone/bootstrap.min.js" };
        public static readonly string[] JqueryBaseIScroll = { "Phone/iscroll.js" };
        public static readonly string[] JqueryMobileJsPath = { "Phone/jquery.mobile-1.4.5.min.js" };
        public static readonly string[] JqueryMobileCssPath = { "Phone/jquery.mobile-1.4.5.min.css"};
        public static readonly string[] OpenPopupJsPath = { "Framework/jquery.jmpopups-0.5.1.js", "Framework/OpenPopup.js" };
        //private static readonly string[] MobileJsPath = { "Phone/jquery.mobile-1.1.0.min.js", "Phone/jquery.mmenu.min.js", "Phone/addons/jquery.mmenu.dragopen.min.js", "Phone/hammer.min.js" };
        //private static readonly string[] MobileCssPath = { "Phone/PhoneSite.css", "Phone/jquery.mobile-1.1.0.min.css", "Phone/jquery.mobile.structure-1.1.0.min.css", "Phone/jquery.mobile.theme-1.1.0.min.css", "Phone/jquery.mmenu.css", "Phone/addons/jquery.mmenu.dragopen.css" };
        private static readonly string[] TreeViewJsPath = { "TreeView/jquery.ztree.core-3.0.min.js", "TreeView/jquery.ztree.excheck-3.0.min.js" };
        private static readonly string[] HighchartsJsPath = { "Highcharts/highcharts.js", "Highcharts/gray.js", "Highcharts/exporting.js", "Highcharts/drilldown.js"};
        private static readonly string[] RateStarJsPath = { "RateStar/rater-star.js"};
        private static readonly string[] DateTimeJsPath = { "Framework/jquery.datetimepicker.js" };
        private const string CommonLinkCssTemplate = "<link href='{0}' rel='stylesheet' type='text/css' />";
        private const string CommonLinkJsTemplate = "<script src='{0}' type='text/javascript'></script>";

        public static MvcHtmlString LoadPageCssJs(this UrlHelper url, bool css = true, bool js = true)
        {
            var routeDate = url.RequestContext.RouteData;

            var area = routeDate.DataTokens["area"].ToString();
            var controller = routeDate.Values["controller"].ToString();
            var action = routeDate.Values["action"].ToString();

            var sb = new StringBuilder();

            if (css)
            {
                sb.AppendLine(Css(url, string.Format("{0}/{1}/{2}.css", area, controller, action)).ToString());
            }

            if (js)
            {
                sb.AppendLine(Js(url, string.Format("{0}/{1}/{2}.js", area, controller, action)).ToString());
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString LoadHighchartsJS(this UrlHelper url)
        {
            return url.CommonJs(HighchartsJsPath);
        }

        public static MvcHtmlString CommonCssMain(this UrlHelper url)
        {
            return LoadCss(url, CommonCssBasePath, CommonCssPath);
        }

        public static MvcHtmlString CommonCss(this UrlHelper url, params string[] filePath)
        {
            return LoadCss(url, CommonCssBasePath, filePath);
        }

        public static MvcHtmlString FrameworkCss(this UrlHelper url, params string[] filePath)
        {
            return LoadCss(url, FrameworkCssBasePath, filePath);
        }
        public static MvcHtmlString PhoneCss(this UrlHelper url, params string[] filePath)
        {
            return LoadCss(url, PhoneCssBasePath, filePath);
        }
        public static MvcHtmlString Css(this UrlHelper url, params string[] filePath)
        {
            return LoadCss(url, CssBasePath, filePath);
        }

        private static MvcHtmlString LoadCss(this UrlHelper url, string rootPath, params string[] filePath)
        {
            return LoadResource(url, CommonLinkCssTemplate, rootPath, filePath);
        }

        public static MvcHtmlString JQueryBaseJs(this UrlHelper url, bool load = true)
        {
            return load ? FrameworkJs(url, JQueryBasePath) : MvcHtmlString.Empty;
        }
        public static MvcHtmlString jsrender(this UrlHelper url, bool load = true)
        {
            return load ? FrameworkJs(url, jsrenderPath) : MvcHtmlString.Empty;
        }
        public static MvcHtmlString Json2(this UrlHelper url, bool load = true)
        {
            return load ? FrameworkJs(url, Json2Path) : MvcHtmlString.Empty;
        }

        public static MvcHtmlString JQueryValidateJs(this UrlHelper url, bool load = true)
        {
            return load ? FrameworkJs(url, JqueryValidatePath, JqueryValidateUnobtrusivePath) : MvcHtmlString.Empty;
        }

        public static MvcHtmlString CommonJsMain(this UrlHelper url, bool load = true)
        {
            return load ? LoadScript(url, CommonJsBasePath, CommonJsPath) : MvcHtmlString.Empty;
        }

        public static MvcHtmlString CommonJs(this UrlHelper url, params string[] filePath)
        {
            return LoadScript(url, CommonJsBasePath, filePath);
        }

        public static MvcHtmlString FrameworkJs(this UrlHelper url, params string[] filePath)
        {
            return LoadScript(url, FrameworkScriptBasePath, filePath);
        }
        public static MvcHtmlString PopupJs(this UrlHelper url, params string[] filePath)
        {
            return Concat(url.CommonJs(OpenPopupJsPath));
        }
        public static MvcHtmlString PhoneJs(this UrlHelper url, params string[] filePath)
        {
            return LoadScript(url, PhoneScriptBasePath, filePath);
        }
        public static MvcHtmlString Js(this UrlHelper url, params string[] filePath)
        {
            return LoadScript(url, ScriptBasePath, filePath);
        }

        public static MvcHtmlString MobileResource(this UrlHelper url)
        {
            return Concat(url.CommonCss(JquereyMmenuCssPath), url.CommonJs(JqueryMmenuJsPath));
        }

        public static MvcHtmlString JqueryMobileResource(this UrlHelper url)
        {
            return Concat(url.CommonJs(JqueryBase183Path),url.LoadPageCssJs(), url.CommonCss(JqueryMobileCssPath), url.CommonJs(JqueryMobileJsPath));
        }
        public static MvcHtmlString BootStrapResource(this UrlHelper url)
        {
            return Concat(url.CommonCss(BootStrapCssPath), url.CommonJs(BootStrapPath));
        }

        public static MvcHtmlString TreeViewResource(this UrlHelper url)
        {
            return Concat(url.CommonCss(TreeViewCssPath),
                          url.CommonJs(TreeViewJsPath));
        }

        public static MvcHtmlString DateTimeResource(this UrlHelper url)
        {
            return Concat(url.CommonCss(DateTimeCssPath),
                          url.CommonJs(DateTimeJsPath));
        }
        public static MvcHtmlString RateStarResource(this UrlHelper url)
        {
            return Concat(url.CommonJs(RateStarJsPath),
                url.CommonCss(RateStarCssPath));
        }

        public static MvcHtmlString Concat(this MvcHtmlString s, params MvcHtmlString[] other)
        {
            var sb = new StringBuilder(s.ToString());

            if (other != null && other.Length > 0)
            {
                other.Each((i, t) => sb.AppendLine(t.ToString()));
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        private static MvcHtmlString LoadScript(this UrlHelper url, string rootPath, params string[] filePath)
        {
            return LoadResource(url, CommonLinkJsTemplate, rootPath, filePath);
        }

        private static MvcHtmlString LoadResource(this UrlHelper url, string format, string rootPath, params string[] filePath)
        {
            var sb = new StringBuilder();

            if (filePath != null && filePath.Length > 0)
            {
                filePath.Each((i, s) => sb.AppendFormat(format, url.Content(rootPath + s)));
            }

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}