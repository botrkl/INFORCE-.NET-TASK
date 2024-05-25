using URLShortener.DAL.Entities;

namespace URLShortener.DAL.Repositories.Intefaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<bool> CheckUserExistByUsernameAsync(string username);
        public Task<User?> GetUserByUsernameAsync(string username);
    }
}
