using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using BasicFramework.Logger;
using BasicFramework.WebAPI.Common;

namespace BasicFramework.WebAPI.Handler
{
    public class ValidateHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string shipperID = string.Empty;
            string customerID = string.Empty;
            string userType = string.Empty;
            int matchHeaderCount = 1;
            //int matchHeaderCount = request.Headers.Count((item) =>
            //{
            //    if ("UserToken".Equals(item.Key))
            //    {
            //        foreach (var str in item.Value)
            //        {
            //            var shipper = ApplicationConfigHelper.GetApplicationShippers().FirstOrDefault(s => string.Equals(s.Str3, str, StringComparison.OrdinalIgnoreCase));
            //            var customer = ApplicationConfigHelper.GetApplicationCustomers().FirstOrDefault(c => string.Equals(c.Str20, str, System.StringComparison.OrdinalIgnoreCase));
            //            if (shipper != null)
            //            {
            //                RunbowLogger.LogInfo(shipper.Name + "于" + DateTime.Now.ToString() + "访问应用");
            //                shipperID = shipper.ID.ToString();
            //                userType = "1";
            //                return true;
            //            }
            //            if (customer != null)
            //            {
            //                RunbowLogger.LogInfo(customer.Name + "于" + DateTime.Now.ToString() + "访问应用");
            //                customerID = customer.ID.ToString();
            //                userType = "0";
            //                return true;
            //            }

            //        }
            //    }

            //    return false;
            //});

            if (matchHeaderCount > 0)
            {
                request.Headers.Add("UserType", userType);
                if (userType == "0")
                {
                    request.Headers.Add("CustomerID", customerID);
                }
                else 
                { 
                    request.Headers.Add("ShipperID", shipperID); 
                }
                return base.SendAsync(request, cancellationToken);
            }

            return Task.Factory.StartNew<HttpResponseMessage>(() => { RunbowLogger.LogError("身份验证不通过"); return new HttpResponseMessage(HttpStatusCode.Forbidden); });
        }
    }
}