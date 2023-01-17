using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShortLink.EntityFramework
{
    public class ShortLinkDbContextFactory  : IDbContextFactory<ShortLinkDbContext>
    {
        private readonly IDbContextFactory<ShortLinkDbContext> _pooledFactory;
        
        public ShortLinkDbContextFactory(IDbContextFactory<ShortLinkDbContext> pooledFactory)
        {
            _pooledFactory = pooledFactory;
        }
        
        public ShortLinkDbContext CreateDbContext()
        {
            return _pooledFactory.CreateDbContext();
        }
        
        public async Task<ShortLinkDbContext> CreateDbContextAsync()
        {
            return await _pooledFactory.CreateDbContextAsync();
        }
    }
}