using CommonUtils.Abstractions.Interface;
using CommonUtils.Constants;
using CommonUtils.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CommonUtils.Builder
{
    public class DbContextBuilder<TContext> : IDbContextBuilder<TContext> where TContext : DbContext, new()
    {
        private readonly DatabaseOptions _options;

        public DbContextBuilder(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public TContext Build()
        {
            var buildOptions = new DbContextOptionsBuilder<TContext>();

            if (_options.DatabaseProvider == DatabaseProviders.MSSQL)
                buildOptions.UseSqlServer(_options.ConnectionString, x => x.UseNetTopologySuite());
            if (_options.DatabaseProvider == DatabaseProviders.Postgres)
                buildOptions.UseNpgsql(_options.ConnectionString);
            if (_options.DatabaseProvider == DatabaseProviders.MySQL)
                buildOptions.UseMySQL(_options.ConnectionString);

            TContext context = (TContext)new DbContext(buildOptions.Options);

            return context;
        }
    }
}
