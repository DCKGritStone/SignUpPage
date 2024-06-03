using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignUpPage.Domain.Entities;
using SignUpPage.Infrastructure.Data;

namespace SignUpPage.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthenticationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("IdentityConneciton") ??
                throw new InvalidOperationException("Connection string 'IdentityConneciton' not found ")));
            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<AuthenticationDbContext>();


            return services;
        }
    }
}
