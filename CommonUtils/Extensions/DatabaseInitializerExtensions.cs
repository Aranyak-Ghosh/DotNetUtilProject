using CommonUtils.Abstractions.Interface;
using CommonUtils.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtils.Extensions
{
    public static class DatabaseInitializerExtensions
    {
        public static IServiceCollection AddDatabaseBuilder<TContext>(this IServiceCollection services) where TContext : DbContext, new()
        {
            return services.AddSingleton<IDbContextBuilder<TContext>, DbContextBuilder<TContext>>();
            
        }
    }
}
