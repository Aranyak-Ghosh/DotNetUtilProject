using CommonUtils.Abstractions.Interface;
using CommonUtils.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils.Logger
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestLogProvider _requestLogger;

        internal RequestLoggingMiddleware(RequestDelegate next, IRequestLogProvider requestLogger)
        {
            _next = next;
            _requestLogger = requestLogger;
        }

        public async Task Invoke(HttpContext context)
        {
            RequestLogEntity logEntity = new RequestLogEntity(context.Request.Method, context.Request.Path, context.TraceIdentifier, context.Connection.RemoteIpAddress.ToString(), context.Request.Path, context.Request.IsHttps, context.Request.QueryString.ToString(), context.User?.FindFirst(ClaimTypes.Email).Value);
            await _next(context);
            logEntity.SetResponseData(context.Response.StatusCode);
            await _requestLogger.LogAsync(logEntity);
        }
    }
}
