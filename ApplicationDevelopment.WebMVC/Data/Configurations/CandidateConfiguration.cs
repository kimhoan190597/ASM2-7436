using ApplicationDevelopment.WebMVC.Data.Entities;
using ApplicationDevelopment.WebMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ApplicationDevelopment.WebMVC.Data.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder
                .Property(b => b.FullName)
            .IsRequired()
                .HasMaxLength(75);

            builder
            .Property(b => b.Name)
                .HasMaxLength(25);

            builder
            .Property(b => b.Phone)
                .HasMaxLength(15);

            builder
                .Property(b => b.Email)
                .HasMaxLength(50);
        }
    }
}
