using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RDSCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnVaseSizeForPlant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "product_type",
                schema: "RDS",
                table: "Plant",
                newName: "vase_size");

            migrationBuilder.AddColumn<int>(
                name: "plant_type",
                schema: "RDS",
                table: "Plant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "plant_type",
                schema: "RDS",
                table: "Plant");

            migrationBuilder.RenameColumn(
                name: "vase_size",
                schema: "RDS",
                table: "Plant",
                newName: "product_type");
        }
    }
}
