﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task4.Data.DbContexts;

#nullable disable

namespace Task4.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Task4.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8846),
                            Email = "abdulloh@itransition.com",
                            Name = "Abdulloh Axmadjonov",
                            Password = "1234",
                            Status = 1
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8851),
                            Email = "p.lebedev@itransition.com",
                            Name = "Pavel Lebedev",
                            Password = "1234",
                            Status = 1
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8857),
                            Email = "risolass@gmail.com",
                            Name = "Risolat Nurillaeva",
                            Password = "1234",
                            Status = 1
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8859),
                            Email = "jasur@icoud.com",
                            Name = "Jasur Rasulov",
                            Password = "1234",
                            Status = 1
                        },
                        new
                        {
                            Id = 5L,
                            CreatedAt = new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8861),
                            Email = "normatov@gmail.com",
                            Name = "Umar Normvatov",
                            Password = "1234",
                            Status = 1
                        },
                        new
                        {
                            Id = 6L,
                            CreatedAt = new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8863),
                            Email = "buggy@gmail.com",
                            Name = "Buggy Anvarjonov",
                            Password = "1234",
                            Status = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
