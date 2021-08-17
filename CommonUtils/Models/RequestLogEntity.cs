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
        public DateTime RequestedOn { get; }
        public string RequestorIP { get; }
        public string RequestUrl { get; }
        public bool isHttps { get; }
        public string QueryString { get; }
        public string RequestorId { get; }
        public int StatusCode { get; private set; }
        public DateTime RespondedOn { get; private set; }

        public RequestLogEntity(string requestMethod,
                                string requestController,
                                string correlationId,
                                string requestorIP,
                                string requestUrl,
                                bool isHttps,
                                string queryString,
                                string requestorId)
        {
            RequestMethod = requestMethod;
            RequestController = requestController;
            CorrelationId = correlationId;
            RequestedOn = DateTime.UtcNow;
            RequestorIP = requestorIP;
            RequestUrl = requestUrl;
            this.isHttps = isHttps;
            QueryString = queryString;
            RequestorId = requestorId;
            PartitionKey = $"{requestMethod}:{RequestController}";
            RowKey = $"{CorrelationId}:{RequestedOn.AddMilliseconds(-RequestedOn.Millisecond).Ticks}";
        }

        public RequestLogEntity()
        {
        }

        public void SetResponseData(int statusCode)
        {
            this.StatusCode = statusCode;
            RespondedOn = DateTime.UtcNow;
        }
    }
}
