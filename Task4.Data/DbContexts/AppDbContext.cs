using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using Task4.Domain.Entities;
using Task4.Domain.Enums;

namespace Task4.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Seed data

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, CreatedAt = DateTime.UtcNow, Email = "abdulloh@itransition.com", Password = "1234", Status = Status.Active, Name = "Abdulloh Axmadjonov" },
            new User { Id = 2, CreatedAt = DateTime.UtcNow, Email = "p.lebedev@itransition.com", Password = "1234", Status = Status.Active, Name = "Pavel Lebedev" },
            new User { Id = 3, CreatedAt = DateTime.UtcNow, Email = "risolass@gmail.com", Password = "1234", Status = Status.Active, Name = "Risolat Nurillaeva" },
            new User { Id = 4, CreatedAt = DateTime.UtcNow, Email = "jasur@icoud.com", Password = "1234", Status = Status.Active, Name = "Jasur Rasulov" },
            new User { Id = 5, CreatedAt = DateTime.UtcNow, Email = "normatov@gmail.com", Password = "1234", Status = Status.Active, Name = "Umar Normvatov" },
            new User { Id = 6, CreatedAt = DateTime.UtcNow, Email = "buggy@gmail.com", Password = "1234", Status = Status.Active, Name = "Buggy Anvarjonov" }
            );

        #endregion
    }
}