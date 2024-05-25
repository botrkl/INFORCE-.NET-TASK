using URLShortener.DAL.Entities;

namespace URLShortener.DAL.Repositories.Intefaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<TEntity>?> GetAllAsync();
    }
}
