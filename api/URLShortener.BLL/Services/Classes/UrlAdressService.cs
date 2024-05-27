using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using URLShortener.BLL.Models;
using URLShortener.BLL.Models.AddModels;
using URLShortener.BLL.Services.Intefaces;
using URLShortener.DAL.Entities;
using URLShortener.DAL.Repositories.Intefaces;

namespace URLShortener.BLL.Services.Classes
{
    public class UrlAdressService : IUrlAdressService
    {
        private readonly IUrlAdressRepository _urlAdressRepository;
        private readonly IMapper _mapper;

        public UrlAdressService(IUrlAdressRepository urlAdressRepository,IMapper mapper)
        {
            _urlAdressRepository = urlAdressRepository;
            _mapper = mapper;
        }

        public async Task AddUrlAdressAsync(string originalUrl, Guid userId)
        {
            if (await _urlAdressRepository.CheckUrlExistAsync(originalUrl))
            {
                throw new Exception($"Url with originalUrl '{originalUrl}' already exist.");
            }
            string hash = GenerateHash(originalUrl);
            string shortUrl = "http://short.url/" + hash;

            var addUrlModel = new AddUrlAdressModel()
            {
                OriginalUrl = originalUrl,
                UserId = userId,
                ShortenedUrl = shortUrl
            };
            var addUrl = _mapper.Map<UrlAdress>(addUrlModel);
            await _urlAdressRepository.AddAsync(addUrl);
        }
        private string GenerateHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                string hash = Convert.ToBase64String(hashBytes).Substring(0, 6);
                hash = hash.Replace('+', '-').Replace('/', '_');
                return hash;
            }
        }
        public async Task DeleteUrlAdressAsync(Guid urlAdressId)
        {
            await _urlAdressRepository.DeleteAsync(urlAdressId);
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

        public async Task<UrlAdressModel> GetUrlAdressByIdAsync(Guid id)
        {
            var searchedUrl = await _urlAdressRepository.GetByIdAsync(id);
            if (searchedUrl == null)
            {
                throw new Exception($"Url with id '{id}' does not exist.");
            }
            return _mapper.Map<UrlAdressModel>(searchedUrl);
        }
    }
}
