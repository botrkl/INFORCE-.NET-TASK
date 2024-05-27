using URLShortener.BLL.Models;

namespace URLShortener.BLL.Services.Intefaces
{
    public interface IUrlAdressService
    {
        public Task<List<ShortUrlModel>> GetAllShortUrlModelsWithFlagAsync(Guid? userId = null, bool isAdmin = false);
        public Task DeleteUrlAdressAsync(Guid urlAdressId);
        public Task AddUrlAdressAsync(string originalUrl, Guid userId);
        public Task<UrlAdressModel> GetUrlAdressByIdAsync(Guid id);
    }
}
