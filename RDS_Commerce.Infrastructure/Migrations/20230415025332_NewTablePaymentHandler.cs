using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RDSCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTablePaymentHandler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentHandler",
                schema: "RDS",
                columns: table => new
                {
                    idpaymentHandler = table.Column<int>(name: "id_paymentHandler", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentdescription = table.Column<string>(name: "payment_description", type: "varchar(100)", nullable: false),
                    pixkey = table.Column<string>(name: "pix_key", type: "varchar(250)", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHandler", x => x.idpaymentHandler);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentHandler",
                schema: "RDS");
        }
    }
}
