using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Task4.Data.Migrations
{
    public partial class f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "LastLoginTime", "Name", "Password", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4896), "abdulloh@itransition.com", new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4898), "Abdulloh Axmadjonov", "1234", 1, null },
                    { 2L, new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4900), "p.lebedev@itransition.com", new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4901), "Pavel Lebedev", "1234", 1, null },
                    { 3L, new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4902), "risolass@gmail.com", new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4903), "Risolat Nurillaeva", "1234", 1, null },
                    { 4L, new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4905), "jasur@icoud.com", new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4906), "Jasur Rasulov", "1234", 1, null },
                    { 5L, new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4907), "normatov@gmail.com", new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4908), "Umar Normvatov", "1234", 1, null },
                    { 6L, new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4909), "buggy@gmail.com", new DateTime(2023, 5, 31, 13, 11, 59, 85, DateTimeKind.Utc).AddTicks(4910), "Buggy Anvarjonov", "1234", 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
