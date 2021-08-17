using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtils.Models
{
    internal class RequestLogEntity : TableEntity
    {
        public string RequestMethod { get; }
        public string RequestController { get; }
        public string CorrelationId { get; }
        public DateTime RequestTime { get; }
        public string RequestorIP { get; }
        public string RequestUrl { get; }
        public bool isHttps { get; }
        public string QueryString { get; }
        public string RequestorId { get; }
        public int StatusCode { get; }

        public RequestLogEntity(string requestMethod,
                                string requestController,
                                string correlationId,
                                DateTime requestTime,
                                string requestorIP,
                                string requestUrl,
                                bool isHttps,
                                string queryString,
                                string requestorId,
                                int statusCode)
        {
            RequestMethod = requestMethod;
            RequestController = requestController;
            CorrelationId = correlationId;
            RequestTime = requestTime;
            RequestorIP = requestorIP;
            RequestUrl = requestUrl;
            this.isHttps = isHttps;
            QueryString = queryString;
            RequestorId = requestorId;
            StatusCode = statusCode;
        }
    }
}
