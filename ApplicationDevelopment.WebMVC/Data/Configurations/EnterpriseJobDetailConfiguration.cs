using ApplicationDevelopment.WebMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationDevelopment.WebMVC.Data.Configurations
{
    public class EnterpriseJobDetailConfiguration : IEntityTypeConfiguration<EnterpriseJobDetail>
    {
        public void Configure(EntityTypeBuilder<EnterpriseJobDetail> builder)
        {
            builder.Property(cv => cv.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(cv => cv.Requirements)
                .HasMaxLength(2000);
            
        }
    }
}
