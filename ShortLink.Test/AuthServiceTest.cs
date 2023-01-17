using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ShortLink.Test
{
    public class AuthServiceTest : IClassFixture<DbFixture>
    {
        private ServiceProvider _serviceProvider;

        public AuthServiceTest(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }
        
        
    }
}