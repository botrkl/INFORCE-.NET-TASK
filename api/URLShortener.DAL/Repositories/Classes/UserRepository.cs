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
    }
}
