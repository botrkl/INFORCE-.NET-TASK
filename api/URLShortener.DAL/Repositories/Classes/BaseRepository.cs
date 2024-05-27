using Microsoft.EntityFrameworkCore;
using URLShortener.DAL.Context;
using URLShortener.DAL.Entities;
using URLShortener.DAL.Repositories.Intefaces;

namespace URLShortener.DAL.Repositories.Classes
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private URLShortenerDbContext _dbContext;
        public BaseRepository(URLShortenerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task DeleteAsync(Guid id)
        {
            var removeEntity = await _dbContext.Set<TEntity>().FirstAsync(x => x.Id == id);
            _dbContext.Set<TEntity>().Remove(removeEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await _dbContext.Set<TEntity>().ToListAsync();
            return result;
        }
        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            var searchedEntity = await _dbContext.Set<TEntity>().FirstAsync(x => x.Id == id);
            return searchedEntity;
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
