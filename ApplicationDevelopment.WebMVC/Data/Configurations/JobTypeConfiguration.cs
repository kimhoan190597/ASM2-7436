using ApplicationDevelopment.WebMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationDevelopment.WebMVC.Data.Configurations
{
    public class JobTypeConfiguration : IEntityTypeConfiguration<JobType>
    {
        public void Configure(EntityTypeBuilder<JobType> builder)
        {
            builder.Property(cv => cv.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(cv => cv.Description)
                .HasMaxLength(2000);
        }
    }
}
