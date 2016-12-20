using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Storm.InterviewTest.Hearthstone.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Attack = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Faction = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PlayerClass = table.Column<string>(nullable: true),
                    Rarity = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: true),
                    Durability = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
