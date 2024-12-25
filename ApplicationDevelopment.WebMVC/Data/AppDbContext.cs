using ApplicationDevelopment.WebMVC.Data.Configurations;
using ApplicationDevelopment.WebMVC.Data.Entities;
using ApplicationDevelopment.WebMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ApplicationDevelopment.WebMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = "Server=10.25.32.147\\SQLServer, 1433; Database=MusicDbContext; User Id=sa; password=P@ssword12345; TrustServerCertificate=True; Trusted_Connection=False; MultipleActiveResultSets=true;";
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        /// <summary>
        /// Cấu hình ràng buộc đatabase Constraints
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(b => b.FullName)
                .IsRequired()
                .HasMaxLength(75);

            modelBuilder.Entity<User>()
                .Property(b => b.Name)
                .HasMaxLength(25);

            modelBuilder.Entity<User>()
                .Property(b => b.Phone)
                .HasMaxLength(15);

            modelBuilder.Entity<User>()
                .Property(b => b.Email)
                .HasMaxLength(50);

            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new CVConfiguration());
            modelBuilder.ApplyConfiguration(new EnterpriseConfiguration());
            modelBuilder.ApplyConfiguration(new EnterpriseJobDetailConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new JobTypeConfiguration());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<EnterpriseJobDetail> EnterpriseJobDetails { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobType> JobTypes { get; set; }

    }
}
