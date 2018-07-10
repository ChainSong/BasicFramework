using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BasicFramework.Logger;

namespace BasicFramework.WebAPI.Filter
{
    public class UnHandleredExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            RunbowLogger.LogException(context.Exception);
            var errorMessagError = new System.Web.Http.HttpError("Oops some internal Exception. Please contact your administrator") { { "ErrorCode", 500 } };
            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorMessagError);
        }
    }
}