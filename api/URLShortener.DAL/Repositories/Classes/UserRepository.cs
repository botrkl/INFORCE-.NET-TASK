using Microsoft.EntityFrameworkCore;
using URLShortener.DAL.Context;
using URLShortener.DAL.Entities;
using URLShortener.DAL.Repositories.Intefaces;

namespace URLShortener.DAL.Repositories.Classes
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private URLShortenerDbContext _dbContext;
        public UserRepository(URLShortenerDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckUserExistByUsernameAsync(string username)
        {
            var result = await _dbContext.Set<User>().AnyAsync(x => x.Username == username);
            return result;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var user = await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }
    }
}
