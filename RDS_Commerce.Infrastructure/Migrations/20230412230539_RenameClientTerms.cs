using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RDSCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameClientTerms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "acceptance_Terms_and_policies",
                schema: "RDS",
                table: "Client",
                newName: "moment_of_acceptance_Terms_and_policies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "moment_of_acceptance_Terms_and_policies",
                schema: "RDS",
                table: "Client",
                newName: "acceptance_Terms_and_policies");
        }
    }
}
