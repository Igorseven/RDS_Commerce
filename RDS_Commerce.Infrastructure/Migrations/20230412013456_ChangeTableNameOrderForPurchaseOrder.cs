using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RDSCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableNameOrderForPurchaseOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPlant_Order_order_id",
                schema: "RDS",
                table: "OrderPlant");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "RDS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPlant",
                schema: "RDS",
                table: "OrderPlant");

            migrationBuilder.RenameColumn(
                name: "amount",
                schema: "RDS",
                table: "Plant",
                newName: "quantity");

            migrationBuilder.AddColumn<int>(
                name: "id_orderPlantId",
                schema: "RDS",
                table: "OrderPlant",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "asaasCustomer_id",
                schema: "RDS",
                table: "Client",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPlant",
                schema: "RDS",
                table: "OrderPlant",
                column: "id_orderPlantId");

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
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
                    table.PrimaryKey("PK_PurchaseOrder", x => x.idorder);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "RDS",
                        principalTable: "Client",
                        principalColumn: "id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPlant_order_id",
                schema: "RDS",
                table: "OrderPlant",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_ClientId",
                schema: "RDS",
                table: "PurchaseOrder",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPlant_PurchaseOrder_order_id",
                schema: "RDS",
                table: "OrderPlant",
                column: "order_id",
                principalSchema: "RDS",
                principalTable: "PurchaseOrder",
                principalColumn: "id_order",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPlant_PurchaseOrder_order_id",
                schema: "RDS",
                table: "OrderPlant");

            migrationBuilder.DropTable(
                name: "PurchaseOrder",
                schema: "RDS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPlant",
                schema: "RDS",
                table: "OrderPlant");

            migrationBuilder.DropIndex(
                name: "IX_OrderPlant_order_id",
                schema: "RDS",
                table: "OrderPlant");

            migrationBuilder.DropColumn(
                name: "id_orderPlantId",
                schema: "RDS",
                table: "OrderPlant");

            migrationBuilder.DropColumn(
                name: "asaasCustomer_id",
                schema: "RDS",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "quantity",
                schema: "RDS",
                table: "Plant",
                newName: "amount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPlant",
                schema: "RDS",
                table: "OrderPlant",
                columns: new[] { "order_id", "plant_id" });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "RDS",
                columns: table => new
                {
                    idorder = table.Column<int>(name: "id_order", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    orderstatus = table.Column<int>(name: "order_status", type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                schema: "RDS",
                table: "Order",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPlant_Order_order_id",
                schema: "RDS",
                table: "OrderPlant",
                column: "order_id",
                principalSchema: "RDS",
                principalTable: "Order",
                principalColumn: "id_order",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
