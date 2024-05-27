using URLShortener.BLL.Models;

namespace URLShortener.BLL.Services.Intefaces
{
    public interface IJwtService
    {
        public string GenerateToken(UserModel userModel);
        public Guid GetUserIdFromJwtToken(string token);
        public bool CheckUserIsAdmin(string token);
    }
}
