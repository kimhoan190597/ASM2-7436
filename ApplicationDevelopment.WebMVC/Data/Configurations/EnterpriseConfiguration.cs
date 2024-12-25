using ApplicationDevelopment.WebMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationDevelopment.WebMVC.Data.Configurations
{
    public class EnterpriseConfiguration : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.Property(cv => cv.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(cv => cv.Address)
                .HasMaxLength(250);
            builder.Property(cv => cv.Email)
                .HasMaxLength(100);
            builder.Property(cv => cv.Hotline)
                .HasMaxLength(15);

            builder.Property(cv => cv.TaxNumber)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
