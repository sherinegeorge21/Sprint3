using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_core_xunit.Entities.TestDb
{
    public partial class TestDbContext : DbContext
    {

        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Tasks> Tasks { get; set; }

        public virtual DbSet<Projects> Projects { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("SampleMemoryDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");


                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Email).IsRequired();


                entity.Property(e => e.Password).IsRequired();

            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");


                entity.Property(e => e.ProjectID).IsRequired();

                entity.Property(e => e.Status).IsRequired();

                entity.Property(e => e.AssignedToUserID).IsRequired();


                entity.Property(e => e.Detail).IsRequired();

                entity.Property(e => e.CreatedOn).IsRequired();

            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");


                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Detail).IsRequired();

  
                entity.Property(e => e.CreatedOn).IsRequired();

            });

            base.OnModelCreating(modelBuilder);
        }



    }
}
