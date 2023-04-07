using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RDSCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTablesAccountIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountIdentity",
                schema: "RDS",
                columns: table => new
                {
                    idaccountIdentity = table.Column<string>(name: "id_accountIdentity", type: "nvarchar(450)", nullable: false),
                    registrationdate = table.Column<DateTime>(name: "registration_date", type: "date", nullable: false),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    normalizedlogin = table.Column<string>(name: "normalized_login", type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    normalizedemail = table.Column<string>(name: "normalized_email", type: "nvarchar(max)", nullable: true),
                    emailconfirmed = table.Column<bool>(name: "email_confirmed", type: "bit", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    securitystamp = table.Column<string>(name: "security_stamp", type: "nvarchar(max)", nullable: true),
                    concurrencystamp = table.Column<string>(name: "concurrency_stamp", type: "nvarchar(max)", nullable: true),
                    cellphone = table.Column<string>(name: "cell_phone", type: "nvarchar(max)", nullable: true),
                    cellphoneconfirmed = table.Column<bool>(name: "cell_phone_confirmed", type: "bit", nullable: false),
                    twofactorenabled = table.Column<bool>(name: "two_factor_enabled", type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    lockoutenabled = table.Column<bool>(name: "lockout_enabled", type: "bit", nullable: false),
                    accessfailedcount = table.Column<int>(name: "access_failed_count", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountIdentity", x => x.idaccountIdentity);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "RDS",
                columns: table => new
                {
                    idclient = table.Column<Guid>(name: "id_client", type: "uniqueidentifier", nullable: false),
                    documentnamber = table.Column<string>(name: "document_namber", type: "varchar(20)", nullable: false),
                    accepttermspolicies = table.Column<bool>(name: "accept_terms_policies", type: "bit", nullable: false),
                    acceptanceTermsandpolicies = table.Column<DateTime>(name: "acceptance_Terms_and_policies", type: "datetime2", nullable: false),
                    fullname = table.Column<string>(name: "full_name", type: "varchar(150)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    registrationdate = table.Column<DateTime>(name: "registration_date", type: "datetime2", nullable: false),
                    accountIdentityid = table.Column<string>(name: "accountIdentity_id", type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.idclient);
                    table.ForeignKey(
                        name: "FK_Client_AccountIdentity_accountIdentity_id",
                        column: x => x.accountIdentityid,
                        principalSchema: "RDS",
                        principalTable: "AccountIdentity",
                        principalColumn: "id_accountIdentity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                schema: "RDS",
                columns: table => new
                {
                    idmanager = table.Column<Guid>(name: "id_manager", type: "uniqueidentifier", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    fullname = table.Column<string>(name: "full_name", type: "varchar(150)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    registrationdate = table.Column<DateTime>(name: "registration_date", type: "datetime2", nullable: false),
                    accountIdentityid = table.Column<string>(name: "accountIdentity_id", type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.idmanager);
                    table.ForeignKey(
                        name: "FK_Manager_AccountIdentity_accountIdentity_id",
                        column: x => x.accountIdentityid,
                        principalSchema: "RDS",
                        principalTable: "AccountIdentity",
                        principalColumn: "id_accountIdentity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "RDS",
                columns: table => new
                {
                    idorder = table.Column<int>(name: "id_order", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderstatus = table.Column<int>(name: "order_status", type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.idorder);
                    table.ForeignKey(
                        name: "FK_Order_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "RDS",
                        principalTable: "Client",
                        principalColumn: "id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddress",
                schema: "RDS",
                columns: table => new
                {
                    idshippingAddress = table.Column<int>(name: "id_shippingAddress", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    selectedforshipping = table.Column<bool>(name: "selected_for_shipping", type: "bit", nullable: false),
                    street = table.Column<string>(type: "varchar(100)", nullable: false),
                    district = table.Column<string>(type: "varchar(70)", nullable: false),
                    city = table.Column<string>(type: "varchar(70)", nullable: false),
                    state = table.Column<string>(type: "char(2)", nullable: false),
                    complement = table.Column<string>(type: "varchar(250)", nullable: false),
                    number = table.Column<string>(type: "varchar(10)", nullable: false),
                    country = table.Column<string>(type: "varchar(50)", nullable: false),
                    zipcode = table.Column<string>(name: "zip_code", type: "varchar(10)", nullable: false),
                    clientid = table.Column<Guid>(name: "client_id", type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddress", x => x.idshippingAddress);
                    table.ForeignKey(
                        name: "FK_ShippingAddress_Client_client_id",
                        column: x => x.clientid,
                        principalSchema: "RDS",
                        principalTable: "Client",
                        principalColumn: "id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPlant",
                schema: "RDS",
                columns: table => new
                {
                    plantid = table.Column<int>(name: "plant_id", type: "int", nullable: false),
                    orderid = table.Column<int>(name: "order_id", type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPlant", x => new { x.orderid, x.plantid });
                    table.ForeignKey(
                        name: "FK_OrderPlant_Order_order_id",
                        column: x => x.orderid,
                        principalSchema: "RDS",
                        principalTable: "Order",
                        principalColumn: "id_order",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPlant_Plant_plant_id",
                        column: x => x.plantid,
                        principalSchema: "RDS",
                        principalTable: "Plant",
                        principalColumn: "id_plant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_accountIdentity_id",
                schema: "RDS",
                table: "Client",
                column: "accountIdentity_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manager_accountIdentity_id",
                schema: "RDS",
                table: "Manager",
                column: "accountIdentity_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                schema: "RDS",
                table: "Order",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPlant_plant_id",
                schema: "RDS",
                table: "OrderPlant",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_client_id",
                schema: "RDS",
                table: "ShippingAddress",
                column: "client_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manager",
                schema: "RDS");

            migrationBuilder.DropTable(
                name: "OrderPlant",
                schema: "RDS");

            migrationBuilder.DropTable(
                name: "ShippingAddress",
                schema: "RDS");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "RDS");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "RDS");

            migrationBuilder.DropTable(
                name: "AccountIdentity",
                schema: "RDS");
        }
    }
}
