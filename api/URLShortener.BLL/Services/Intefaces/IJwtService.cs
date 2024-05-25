using URLShortener.BLL.Models;

namespace URLShortener.BLL.Services.Intefaces
{
    public interface IJwtService
    {
        public Task<string> GenerateToken(UserModel userModel);
    }
}
