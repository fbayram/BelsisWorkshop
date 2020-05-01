using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace BelsisWorkshop.Api
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,ITicket ticket)
        {
            //ticket.Adi = "Belsis";
            var cultureparam = context.Request.Query["culture"];
            if (!string.IsNullOrEmpty(cultureparam.FirstOrDefault()))
            {
                var d = 5d;
                //var dstring = d.ToString("c");
                var culture = new CultureInfo(cultureparam);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture= culture;
                Thread.CurrentThread.CurrentUICulture= culture;

                await context.Response.WriteAsync(d.ToString("c"));

            }

            await _next(context);
        }
    }


    public static class MiddlewareExt
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }

        //public static string GetObjectString(this object obj)
        //{
        //    return obj.ToString();
        //}
    }
}
