using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using BasicFramework.MobileWeb.Models.HtmlHelp;
 

namespace System.Web.Mvc
{
    public static class HtmlHelperExtension
    {
        public static bool IsReadonly(this HtmlHelper html)
        {
            var o = html.ViewContext.Controller.ViewBag.___IsReadonly___;

            return o == null || !(o is bool) ? false : (bool)o;
        }

        public static MvcHtmlString AutoTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool edit = true)
        {
            if (!edit || htmlHelper.IsReadonly())
                return htmlHelper.DisplayTextFor(expression);

            return htmlHelper.TextBoxFor(expression);
        }

        public static MvcHtmlString AutoTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (htmlHelper.IsReadonly())
                return htmlHelper.DisplayTextFor(expression);

            return htmlHelper.TextBoxFor(expression, htmlAttributes);
        }

        public static MvcHtmlString AutoTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool edit = true)
        {
            if (!edit || htmlHelper.IsReadonly())
                return htmlHelper.DisplayTextFor(expression);

            return htmlHelper.TextBoxFor(expression, htmlAttributes);
        }

        public static MvcHtmlString AutoTextAreaFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            object htmlAttributes,
            bool edit = true)
        {
            if (!edit || htmlHelper.IsReadonly())
                return htmlHelper.DisplayTextFor(expression);

            return htmlHelper.TextAreaFor(expression, htmlAttributes);
        }

        public static MvcHtmlString Back(this HtmlHelper html)
        {
            return new MvcHtmlString("<input type='button' value='返回' onclick='if(window.history) history.back()' />");
        }

        public static MvcHtmlString NecessaryFlag(this HtmlHelper html)
        {
            if (html.IsReadonly())
                return MvcHtmlString.Empty;
            return new MvcHtmlString("<label class='need'>*</label>");
        }

        public static MvcHtmlString AutoValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool show = true)
        {
            if (!show || htmlHelper.IsReadonly())
                return MvcHtmlString.Empty;

            return htmlHelper.ValidationMessageFor(expression);
        }

        /// <summary>
        /// 批量上传回传单
        /// </summary>
        public static MvcHtmlString MultipleImageUpload(this HtmlHelper helper, string fileElementID, string hiddenFileID,bool isReadOnly = false, bool loadJs = true, bool IsCoverOld = true)
        {
            FileUploadViewModel model = new FileUploadViewModel() { FileElementID = fileElementID, HiddenFileID = hiddenFileID, IsMultiple = true, IsReadOnly = isReadOnly, LoadJs = loadJs, IsCoverOld = IsCoverOld };
            return helper.Partial("ImageUpload", model);
        }

        public static MvcHtmlString MultipleFileUpload(this HtmlHelper helper, string fileElementID, string hiddenFileID, bool isReadOnly = false, bool loadJs = true, bool IsCoverOld = true)
        {
            FileUploadViewModel model = new FileUploadViewModel() { FileElementID = fileElementID, HiddenFileID = hiddenFileID, IsMultiple = true, IsReadOnly = isReadOnly, LoadJs = loadJs, IsCoverOld = IsCoverOld };
            return helper.Partial("FileUpload", model);
        }        

        public static MvcHtmlString SingleFileUpload(this HtmlHelper helper, string fileElementID, string hiddenFileID, string groupID = "", bool isReadOnly = false, bool loadJs = true, bool onlyShowAudit = false, bool IsCoverOld = true)
        {
            FileUploadViewModel model = new FileUploadViewModel() { FileElementID = fileElementID, HiddenFileID = hiddenFileID, HiddenFileValue = groupID, IsReadOnly = isReadOnly, LoadJs = loadJs, OnlyShowAudit = onlyShowAudit, IsCoverOld = IsCoverOld};
            return helper.Partial("FileUpload", model);
        }

        public static MvcHtmlString Pager(this HtmlHelper helper, int pageIndex, int pageCount, string identify)
        {
            PagerViewModel model = new PagerViewModel() { PageIndex = pageIndex, PageCount = pageCount, Identify = identify };
            return helper.Partial("Pager", model);
        }

        public static bool NotLoad(this ViewContext viewContext, string key)
        {
            bool r = viewContext.Controller.ViewData.ContainsKey(key);

            if (!r) viewContext.Controller.ViewData[key] = true;

            return !r;
        }

        public static MvcHtmlString RegionSelector(this HtmlHelper html, RegionSelector r = null)
        {
            return html.Partial("RegionSelector", r ?? new RegionSelector());
        }

        public static MvcHtmlString ChooseString(this HtmlHelper html, bool trueOrFalse, string Str1, string Str2)
        {
            return trueOrFalse ? new MvcHtmlString(Str1) : new MvcHtmlString(Str2);
        }

    }
}