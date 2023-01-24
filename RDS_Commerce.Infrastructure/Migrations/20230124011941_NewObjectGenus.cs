using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RDSCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewObjectGenus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "specie",
                schema: "RDS",
                table: "Plant");

            migrationBuilder.AddColumn<int>(
                name: "genus_id",
                schema: "RDS",
                table: "Plant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genus",
                schema: "RDS",
                columns: table => new
                {
                    IdGenus = table.Column<int>(name: "Id_Genus", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genusname = table.Column<string>(name: "genus_name", type: "varchar(80)", nullable: false),
                    specie = table.Column<string>(type: "varchar(60)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genus", x => x.IdGenus);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plant_genus_id",
                schema: "RDS",
                table: "Plant",
                column: "genus_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Genus_genus_id",
                schema: "RDS",
                table: "Plant",
                column: "genus_id",
                principalSchema: "RDS",
                principalTable: "Genus",
                principalColumn: "Id_Genus",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Genus_genus_id",
                schema: "RDS",
                table: "Plant");

            migrationBuilder.DropTable(
                name: "Genus",
                schema: "RDS");

            migrationBuilder.DropIndex(
                name: "IX_Plant_genus_id",
                schema: "RDS",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "genus_id",
                schema: "RDS",
                table: "Plant");

            migrationBuilder.AddColumn<string>(
                name: "specie",
                schema: "RDS",
                table: "Plant",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");
        }
    }
}
