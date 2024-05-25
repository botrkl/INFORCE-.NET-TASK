using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URLShortener.DAL.Entities;

namespace URLShortener.DAL.EntitiesConfiguration
{
    public class UrlAdressConfiguration : IEntityTypeConfiguration<UrlAdress>
    {
        public void Configure(EntityTypeBuilder<UrlAdress> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.OriginalUrl)
                .IsRequired();

            builder.Property(x => x.ShortenedUrl)
                .IsRequired();

            builder.Property(x=>x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();
        }
    }
}
