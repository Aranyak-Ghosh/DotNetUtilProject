using CommonUtils.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtils.Logger.Provider.SQL
{
    public class LogDbContext : DbContext
    {
        internal DbSet<RequestLogEntity> RequestLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
