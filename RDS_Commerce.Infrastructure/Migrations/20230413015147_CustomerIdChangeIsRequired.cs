using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RDSCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CustomerIdChangeIsRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "asaasCustomer_id",
                schema: "RDS",
                table: "Client",
                type: "varchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "asaasCustomer_id",
                schema: "RDS",
                table: "Client",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldNullable: true);
        }
    }
}
