// <copyright file="BlockingMiddleware.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable
#if !NETFRAMEWORK
using System.Threading.Tasks;
using System.Web;
using Datadog.Trace.AppSec;
using Microsoft.AspNetCore.Http;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.AspNetCore;

internal class BlockingMiddleware
{
    private readonly RequestDelegate _next;

    internal BlockingMiddleware(RequestDelegate next) => _next = next;

    internal Task Invoke(HttpContext context)
    {
        if (context.Items["block"] is true)
        {
            var sec = Security.Instance;
            var settings = sec.Settings;
            var httpResponse = context.Response;
            if (!httpResponse.HasStarted)
            {
                httpResponse.Clear();
                foreach (var cookie in context.Request.Cookies)
                {
                    httpResponse.Cookies.Delete(cookie.Key);
                }

                httpResponse.Headers.Clear();
                httpResponse.StatusCode = 403;
                var template = settings.BlockedJsonTemplate;
                if (context.Request.Headers["Accept"].ToString().Contains("text/html"))
                {
                    httpResponse.ContentType = "text/html";
                    template = settings.BlockedHtmlTemplate;
                }
                else
                {
                    httpResponse.ContentType = "application/json";
                }

                return httpResponse.WriteAsync(template);
            }

            httpResponse.Body.Dispose();
            return Task.CompletedTask;
        }

        return _next(context);
    }
}
#endif
