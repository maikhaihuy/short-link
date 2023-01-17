using System;
using System.Threading.Tasks;
using ShortLink.EntityFramework;

namespace ShortLink.Base
{
    public class BaseService : IAsyncDisposable
    {
        protected readonly ShortLinkDbContext DbContext;
        protected BaseService(ShortLinkDbContextFactory dbContextFactory)
        {
            DbContext = dbContextFactory.CreateDbContext();
        }
        
        public ValueTask DisposeAsync()
        {
            return DbContext.DisposeAsync();
        }
    }
}