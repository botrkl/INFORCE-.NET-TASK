using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URLShortener.DAL.Entities;

namespace URLShortener.DAL.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Username)
                .IsUnique();
            builder.Property(x => x.Username)
                .IsRequired();

            builder.Property(x => x.HashPassword)
                .IsRequired();

            builder.Property(x => x.IsAdmin)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasMany(x => x.UrlAdresses)
                .WithOne(url => url.CreatedBy)
                .HasForeignKey(url => url.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
