using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShortLink.Apis.Auth;
using ShortLink.Apis.Urls;
using ShortLink.Configurations;
using ShortLink.EntityFramework;

namespace ShortLink.Test
{
    public class DbFixture
    {
        public DbFixture()
        {
            var serviceCollection = new ServiceCollection();

            var config = ReadConfiguration();
            
            serviceCollection.AddPooledDbContextFactory<ShortLinkDbContext>(option =>
            {
                option.UseSqlServer(config["ConnectionStrings:DefaultConnection"], x => x.EnableRetryOnFailure());
            });

            // Auto mapping
            serviceCollection.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            }).CreateMapper());
            
            serviceCollection.AddTransient<ShortLinkDbContextFactory>();
            serviceCollection.AddTransient<IAuthService, AuthService>();
            serviceCollection.AddTransient<IUrlService, UrlService>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
        
        private IConfiguration ReadConfiguration()
        { 
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Test.json")
                .AddEnvironmentVariables() 
                .Build();
            return config;
        }
    }
}