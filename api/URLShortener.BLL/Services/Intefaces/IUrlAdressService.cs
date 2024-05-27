using URLShortener.BLL.Models;

namespace URLShortener.BLL.Services.Intefaces
{
    public interface IUrlAdressService
    {
        public Task<List<ShortUrlModel>> GetAllShortUrlModelsWithFlagAsync(Guid? userId = null, bool isAdmin = false);
    }
}
