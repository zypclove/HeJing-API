using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UltraNuke.CommonMormon.Utils.Exceptions;
using UltraNuke.CommonMormon.Utils.Model;

namespace UltraNuke.CommonMormon.Utils.Middlewares
{
    public class ApiLogMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        private readonly Stopwatch sp;
        private readonly ApiLog apiLog;

        private const string ApiLogTemplate = " {Method}{Scheme}{Host}{Path}{Query}{RequestBody}{ResponseBody}{ExecuteUser}{ExecuteIp}{ExecuteTime}{ExecuteDuration}";

        public ApiLogMiddleware(RequestDelegate next, ILogger<ApiLogMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;

            sp = new Stopwatch();
            apiLog = new ApiLog();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                sp.Restart();

                var originalBodyStream = context.Response.Body;
                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    sp.Start();
                    await next(context);
                    sp.Stop();

                    apiLog.ExecuteTime = DateTime.Now;
                    apiLog.Method = context.Request.Method;
                    apiLog.Scheme = context.Request.Scheme;
                    apiLog.Host = context.Request.Host.ToString();
                    apiLog.Path = context.Request.Path;
                    apiLog.Query = context.Request.QueryString.ToString();
                    apiLog.RequestBody = await FormatRequest(context.Request);
                    apiLog.ResponseBody = await FormatResponse(context.Response);
                    apiLog.ExecuteIp = context.Connection.RemoteIpAddress.ToString();
                    apiLog.ExecuteDuration = sp.ElapsedMilliseconds;

                    logger.LogInformation(ApiLogTemplate, apiLog.ExecuteTime, apiLog.Method, apiLog.Scheme, apiLog.Host, apiLog.Path, apiLog.Query, apiLog.RequestBody, apiLog.ResponseBody, apiLog.ExecuteUser, apiLog.ExecuteIp, apiLog.ExecuteDuration);

                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();
            request.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);
            return text?.Trim().Replace("\r", "").Replace("\n", "");
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            if (response.HasStarted)
            {
                return string.Empty;
            }
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return text?.Trim().Replace("\r", "").Replace("\n", "");
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // 用户操作错误
            if (ex.GetType() == typeof(UserOperationException))
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                logger.LogWarning(ApiLogTemplate, apiLog.ExecuteTime, apiLog.Method, apiLog.Scheme, apiLog.Host, apiLog.Path, apiLog.Query, apiLog.RequestBody, ex.Message, apiLog.ExecuteUser, apiLog.ExecuteIp, apiLog.ExecuteDuration);
            }
            // 微信授权错误
            else if (ex.GetType() == typeof(UnauthorizedException))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                logger.LogWarning(ApiLogTemplate, apiLog.ExecuteTime, apiLog.Method, apiLog.Scheme, apiLog.Host, apiLog.Path, apiLog.Query, apiLog.RequestBody, ex.Message, apiLog.ExecuteUser, apiLog.ExecuteIp, apiLog.ExecuteDuration);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                logger.LogError(ex, ApiLogTemplate, apiLog.ExecuteTime, apiLog.Method, apiLog.Scheme, apiLog.Host, apiLog.Path, apiLog.Query, apiLog.RequestBody, ex.Message, apiLog.ExecuteUser, apiLog.ExecuteIp, apiLog.ExecuteDuration);
            }

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }
    }
}
