using Microsoft.EntityFrameworkCore;
using URLShortener.DAL.Entities;

namespace URLShortener.DAL.DbDataGenerators
{
    public static class UrlAdressDataGenerator
    {
        public static readonly List<UrlAdress> urlAdresses = new List<UrlAdress>
        {
            new()
            {
                Id=Guid.Parse("70C755BD-F96B-4A82-8A0A-A29FBBA009F4"),
                OriginalUrl="OriginalUrl/justForTest",
                ShortenedUrl="ShortenedUrl/justForTest",
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse("9B4673FB-20C2-4341-9A36-A3CFAA22878B")
            },
            new()
            {
                Id=Guid.Parse("78F30A41-A1DA-4C73-B237-7879864D854B"),
                OriginalUrl="OriginalUrl/justForTest",
                ShortenedUrl="ShortenedUrl/justForTest",
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse("9B4673FB-20C2-4341-9A36-A3CFAA22878B")
            },
            new()
            {
                Id=Guid.Parse("8A7E0782-8FB7-4371-986D-B3110255BC59"),
                OriginalUrl="OriginalUrl/justForTest",
                ShortenedUrl="ShortenedUrl/justForTest",
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse("747A1720-4CA3-43E2-93FA-BECC860589DC")
            },
            new()
            {
                Id=Guid.Parse("50A89E67-967E-4D98-916E-C53378A48A6B"),
                OriginalUrl="OriginalUrl/justForTest",
                ShortenedUrl="ShortenedUrl/justForTest",
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse("539AD3F7-7478-4B34-8A09-9509B6F4ADFD")
            }
        };
        public static void Generate(ModelBuilder builder)
        {
            builder.Entity<UrlAdress>()
                .HasData(urlAdresses);
        }
    }
}
