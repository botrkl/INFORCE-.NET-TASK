using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using URLShortener.DAL.Context;
using URLShortener.DAL.Repositories.Classes;
using URLShortener.DAL.Repositories.Intefaces;

namespace URLShortener.DAL.Extensions
{
    public static class DALServiceCollectionExtension
    {
        public static void InjectDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<URLShortenerDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"]);
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUrlAdressRepository, UrlAdressRepository>();
        }
    }
}