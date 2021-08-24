using Microsoft.EntityFrameworkCore;

namespace CommonUtils.Abstractions.Interface
{
    public interface IDbContextBuilder<TContext> where TContext : DbContext, new()
    {
        TContext Build();
    }
}