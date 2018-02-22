using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Context;
using Serilog.Events;

namespace OnionPattern.Api.Configuration.Startup.Logging
{
    /// <summary>
    /// Configures Application Middleware to pass a correlation Id between internal and external
    /// call. This will attach the correlation id to Serilog's Log Context Property bag.
    /// </summary>
    public static class CorrelationMiddleware
    {
        private const string CORRELATIONID = "CorrelationId";
        private const string MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

        /// <summary>
        /// Configure Correlation Id Middleware
        /// </summary>
        /// <param name="application"></param>
        public static void Configure(IApplicationBuilder application)
        {
            application.Use(async (context, next) =>
            {
                //start timing 
                var stopwatch = Stopwatch.StartNew();

                try
                {
                    var nextTask = next.Invoke();

                    //request information
                    var path = context.Request.Path;
                    var method = context.Request.Method;
                    var statusCode = context.Response?.StatusCode;
                    var level = statusCode > 499 ? LogEventLevel.Error : LogEventLevel.Information;

                    // establish correlation id
                    string correlationId;
                    if (context.Request.Headers.TryGetValue("X-Correlation-Id", out var idFromHeader))
                    {
                        correlationId = idFromHeader;
                        Log.Debug("CorrelationId {CorrelationId} accepted from header", correlationId);
                    }
                    else
                    {
                        correlationId = Guid.NewGuid().ToString();
                        Log.Debug("CorrelationId {CorrelationId} generated", correlationId);
                    }

                    // push value into both context areas(log and ambient)
                    CallContext<string>.SetData(CORRELATIONID, correlationId);
                    LogContext.PushProperty(CORRELATIONID, correlationId);

                    //let the rest of the pipeline run
                    await nextTask;
                    stopwatch.Stop();

                    //log results
                    Log.Write(level, MessageTemplate, method, path, statusCode, stopwatch.Elapsed.Milliseconds);
                }
                catch (Exception exception)
                {
                    LogException(context, stopwatch, exception);
                }
            });
        }

        private static void LogException(HttpContext httpContext, Stopwatch sw, Exception ex)
        {
            sw.Stop();

            LogForErrorContext(httpContext).Error(
                ex,
                MessageTemplate,
                httpContext.Request.Method,
                httpContext.Request.Path,
                500,
                sw.Elapsed.TotalMilliseconds);
        }

        private static ILogger LogForErrorContext(HttpContext httpContext)
        {
            var request = httpContext.Request;

            var result = Log
                .ForContext("RequestHeaders", request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), true)
                .ForContext("RequestHost", request.Host)
                .ForContext("RequestProtocol", request.Protocol);

            if (request.HasFormContentType)
            {
                result = result.ForContext("RequestForm", request.Form.ToDictionary(v => v.Key, v => v.Value.ToString()));
            }

            return result;
        }
    }
}
