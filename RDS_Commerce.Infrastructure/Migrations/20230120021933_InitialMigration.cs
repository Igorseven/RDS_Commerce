using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RDSCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RDS");

            migrationBuilder.CreateTable(
                name: "Plant",
                schema: "RDS",
                columns: table => new
                {
                    idplant = table.Column<int>(name: "id_plant", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(60)", nullable: false),
                    specie = table.Column<string>(type: "varchar(60)", nullable: false),
                    description = table.Column<string>(type: "varchar(500)", nullable: true)
                        .Annotation("SqlServer:Sparse", true),
                    amount = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    producttype = table.Column<int>(name: "product_type", type: "int", nullable: false),
                    registrationdate = table.Column<DateTime>(name: "registration_date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.idplant);
                });

            migrationBuilder.CreateTable(
                name: "PlantImage",
                schema: "RDS",
                columns: table => new
                {
                    idfileImage = table.Column<int>(name: "id_fileImage", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filename = table.Column<string>(name: "file_name", type: "varchar(40)", nullable: false),
                    fileextension = table.Column<string>(name: "file_extension", type: "varchar(10)", nullable: false),
                    filebytes = table.Column<byte[]>(name: "file_bytes", type: "varbinary(max)", nullable: false),
                    mainimage = table.Column<bool>(name: "main_image", type: "bit", nullable: false),
                    registrationdate = table.Column<DateTime>(name: "registration_date", type: "datetime2", nullable: false),
                    plantid = table.Column<int>(name: "plant_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantImage", x => x.idfileImage);
                    table.ForeignKey(
                        name: "FK_PlantImage_Plant_plant_id",
                        column: x => x.plantid,
                        principalSchema: "RDS",
                        principalTable: "Plant",
                        principalColumn: "id_plant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantImage_plant_id",
                schema: "RDS",
                table: "PlantImage",
                column: "plant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantImage",
                schema: "RDS");

            migrationBuilder.DropTable(
                name: "Plant",
                schema: "RDS");
        }
    }
}
