using Microsoft.Extensions.DependencyInjection;
using URLShortener.BLL.Mapping;
using URLShortener.BLL.Services.Classes;
using URLShortener.BLL.Services.Intefaces;

namespace URLShortener.BLL.Extensions
{
    public static class BLLServiceCollectionExtension
    {
        public static void InjectBLL(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserMapperProfile));
            services.AddAutoMapper(typeof(UrlAdressMapperProfile));

            services.AddScoped<IUrlAdressService, UrlAdressService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPasswordHashingService, PasswordHashingService>();
        }
    }
}
