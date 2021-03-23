using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using UltraNuke.CommonMormon.Utils.Model;

namespace UltraNuke.CommonMormon.Utils.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelValidateActionFilterAttribute: ActionFilterAttribute
    {
        private readonly ILogger logger;
        private readonly ApiLog apiLog;
        private const string ApiLogTemplate = " {Method}{Scheme}{Host}{Path}{Query}{RequestBody}{ResponseBody}{ExecuteUser}{ExecuteIp}{ExecuteTime}{ExecuteDuration}";

        public ModelValidateActionFilterAttribute(ILogger<ModelValidateActionFilterAttribute> logger)
        {
            this.logger = logger;
            apiLog = new ApiLog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //获取验证失败的模型字段
                var errors = context.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => e.Value.Errors.First().ErrorMessage)
                    .ToList();
                var str = string.Join("|", errors);
                
                var originalBodyStream = context.HttpContext.Response.Body;
                using (var responseBody = new MemoryStream())
                {
                    context.HttpContext.Response.Body = responseBody;

                    apiLog.ExecuteTime = DateTime.Now;
                    apiLog.Method = context.HttpContext.Request.Method;
                    apiLog.Scheme = context.HttpContext.Request.Scheme;
                    apiLog.Host = context.HttpContext.Request.Host.ToString();
                    apiLog.Path = context.HttpContext.Request.Path;
                    apiLog.Query = context.HttpContext.Request.QueryString.ToString();
                    apiLog.RequestBody = FormatRequest(context.HttpContext.Request);
                    apiLog.ResponseBody = str;
                    apiLog.ExecuteIp = context.HttpContext.Connection.RemoteIpAddress.ToString();
                    apiLog.ExecuteDuration = 0;

                    logger.LogWarning(ApiLogTemplate, apiLog.ExecuteTime, apiLog.Method, apiLog.Scheme, apiLog.Host, apiLog.Path, apiLog.Query, apiLog.RequestBody, apiLog.ResponseBody, apiLog.ExecuteUser, apiLog.ExecuteIp, apiLog.ExecuteDuration);

                    responseBody.CopyTo(originalBodyStream);
                }

                var result = new
                {
                    error = str
                };

                context.Result = new BadRequestObjectResult(result);
            }
        }

        private string FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();
            request.Body.Seek(0, SeekOrigin.Begin);
            var text = new StreamReader(request.Body).ReadToEnd();
            request.Body.Seek(0, SeekOrigin.Begin);
            return text?.Trim().Replace("\r", "").Replace("\n", "");
        }
    }
}
