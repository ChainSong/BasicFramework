using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc.Html;

namespace System.Web.Mvc
{
    public static class CalendarExtension
    {
        public static MvcHtmlString Calendar(this HtmlHelper html, string name, string className = null, DateTime? dateTime = null)
        {
            return GenerateCalendar(html, name, className, dateTime);
        }

        public static MvcHtmlString CalendarDateTime(this HtmlHelper html, string name, string className = null, DateTime? dateTime = null)
        {
            return GenerateCalendarForDateTime(html, name, className, dateTime);
        }

        public static MvcHtmlString CalendarFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression,string className = null)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            DateTime? nullableDateTime = null;
            DateTime dateTime;

            object data = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, html.ViewData).Model;

            if (data != null && DateTime.TryParse(data.ToString(), out dateTime))
            {
                if (dateTime == DateTime.MinValue)
                {
                    nullableDateTime = null;
                }
                else
                {
                    nullableDateTime = dateTime;
                }
            }

            return GenerateCalendar(html, name, className, nullableDateTime);
        }

        public static MvcHtmlString CalendarDateTimeFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            DateTime? nullableDateTime = null;
            DateTime dateTime;

            object data = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, html.ViewData).Model;

            if (data != null && DateTime.TryParse(data.ToString(), out dateTime))
            {
                if (dateTime == DateTime.MinValue)
                {
                    nullableDateTime = null;
                }
                else
                {
                    nullableDateTime = dateTime;
                }
            }

            return GenerateCalendarForDateTime(html, name, null, nullableDateTime);
        }

        private static MvcHtmlString GenerateCalendar(this HtmlHelper html, string name, string className, DateTime? dateTime)
        {
            var map = new ViewDataDictionary();
            map["DateTimeName"] = name;
            map["ClassName"] = className;
            return html.Partial("Date", dateTime, map);
        }

        private static MvcHtmlString GenerateCalendarForDateTime(this HtmlHelper html, string name, string className, DateTime? dateTime)
        {
            var map = new ViewDataDictionary();
            map["DateTimeName_DateTimePicker"] = name;
            map["ClassName_DateTimePicker"] = className;
            return html.Partial("DateTime", dateTime, map);
        }

        public static MvcHtmlString CalendarRange(this HtmlHelper html, string name, string className = null, DateTime? startDateTime = null, DateTime? endDateTime = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Calendar(html, "start_" + name, className, startDateTime).ToString());
            sb.Append("~");
            sb.Append(Calendar(html, "end_" + name, className, endDateTime).ToString());
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}