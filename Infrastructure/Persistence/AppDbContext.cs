using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>(entity =>
            {
            
                entity.ToTable("Events");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnType("TEXT")
                      .IsRequired();

                entity.Property(e => e.Title)
                      .HasColumnType("TEXT")
                      .IsRequired();

                entity.Property(e => e.Start)
                      .HasColumnType("TEXT")
                      .IsRequired();

                entity.Property(e => e.End)
                      .HasColumnType("TEXT")
                      .IsRequired();
                                entity.Property(e => e.Type)
                      .HasColumnType("INTEGER")
                      .IsRequired();

                entity.Property(e => e.Description)
                      .HasColumnType("TEXT");
            });
        }
    }
}