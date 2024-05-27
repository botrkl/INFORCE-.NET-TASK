﻿using URLShortener.DAL.Entities;

namespace URLShortener.DAL.Repositories.Intefaces
{
    public interface IUrlAdressRepository : IBaseRepository<UrlAdress>
    {
        public Task<bool> CheckUrlExistAsync(string OriginalUrl);
    }
}
