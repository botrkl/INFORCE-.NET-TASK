using URLShortener.BLL.Models;
using URLShortener.BLL.Services.Intefaces;
using URLShortener.DAL.Repositories.Intefaces;

namespace URLShortener.BLL.Services.Classes
{
    public class UrlAdressService : IUrlAdressService
    {
        private readonly IUrlAdressRepository _urlAdressRepository;
        public UrlAdressService(IUrlAdressRepository urlAdressRepository)
        {
            _urlAdressRepository = urlAdressRepository;
        }
        public async Task<List<ShortUrlModel>> GetAllShortUrlModelsWithFlagAsync(Guid? userId = null, bool isAdmin = false)
        {
            var allUrls = await _urlAdressRepository.GetAllAsync();
            var shortUrlModels = new List<ShortUrlModel>();

            foreach (var urlAdress in allUrls)
            {
                var canBeDeleted = isAdmin ? true : (userId.HasValue && urlAdress.UserId == userId);
                shortUrlModels.Add(new ShortUrlModel
                {
                    Id = urlAdress.Id,
                    OriginalUrl = urlAdress.OriginalUrl,
                    ShortenedUrl = urlAdress.ShortenedUrl,
                    canBeDeleted = canBeDeleted
                });
            }

            return shortUrlModels;
        }
    }
}
