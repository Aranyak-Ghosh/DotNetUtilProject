using Ardalis.GuardClauses;
using CommonUtils.Abstractions.Interface;
using CommonUtils.Builder;
using CommonUtils.Logger.Provider.SQL;
using CommonUtils.Models;
using CommonUtils.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils.Logger.Provider
{
    public class SQLRequestLogProvider : IRequestLogProvider
    {
        private readonly SQLLoggerOptions _options;
        private readonly LogDbContext _context;
        
        private readonly DbSet<RequestLogEntity> _entity;

        public SQLRequestLogProvider(IOptions<SQLLoggerOptions> options, DbContextBuilder<LogDbContext> _contextBuilder)
        {
            _options = options.Value;
            _context = _contextBuilder.Build();
            _entity = _context.Set<RequestLogEntity>();
        }


        async Task IRequestLogProvider.LogAsync(RequestLogEntity logItem)
        {
            Guard.Against.Null(logItem, nameof(logItem));
            _entity.Add(logItem);
            await _context.SaveChangesAsync();
        }
    }
}
