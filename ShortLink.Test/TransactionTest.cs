using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ShortLink.Test
{
    public class TransactionTest : IClassFixture<DbFixture>
    {
        private ServiceProvider _serviceProvider;

        public TransactionTest(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }
    }
}