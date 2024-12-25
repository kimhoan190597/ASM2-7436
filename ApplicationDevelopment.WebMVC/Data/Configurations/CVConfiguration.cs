using ApplicationDevelopment.WebMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationDevelopment.WebMVC.Data.Configurations
{
    public class CVConfiguration : IEntityTypeConfiguration<CV>
    {
        public void Configure(EntityTypeBuilder<CV> builder)
        {
            builder.Property(cv => cv.Name)
                .IsRequired()
                .HasMaxLength(75);
        }
    }
}
