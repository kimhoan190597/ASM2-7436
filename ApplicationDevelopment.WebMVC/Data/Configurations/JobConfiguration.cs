using ApplicationDevelopment.WebMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationDevelopment.WebMVC.Data.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.Property(cv => cv.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(cv => cv.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(cv => cv.Requirements)
                .HasMaxLength(2000);
        }
    }
}
