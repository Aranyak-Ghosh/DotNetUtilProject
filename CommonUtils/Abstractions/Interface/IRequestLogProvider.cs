using CommonUtils.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils.Abstractions.Interface
{
    internal interface IRequestLogProvider
    {
        Task LogAsync(RequestLogEntity logItem);
    }
}
