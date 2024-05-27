using Microsoft.EntityFrameworkCore;
using URLShortener.DAL.Context;
using URLShortener.DAL.Entities;
using URLShortener.DAL.Repositories.Intefaces;

namespace URLShortener.DAL.Repositories.Classes
{
    public class UrlAdressRepository : BaseRepository<UrlAdress>, IUrlAdressRepository
    {
        private URLShortenerDbContext _dbContext;
        public UrlAdressRepository(URLShortenerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckUrlExistAsync(string OriginalUrl)
        {
            var result = await _dbContext.Set<UrlAdress>().AnyAsync(x => x.OriginalUrl == OriginalUrl);
            return result;
        }
    }
}
