using URLShortener.BLL.Models.AddModels;

namespace URLShortener.BLL.Services.Intefaces
{
    public interface IAuthService
    {
        public Task<string> AuthenticateAsync(string username, string password);
        public Task<string> RegisterAsync(AddUserModel userModel);
    }
}
