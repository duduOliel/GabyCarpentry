using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GabyCarpenter.Migrations
{
    public partial class orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Items_orderdIteId",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderModel_orderdIteId",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "orderdIteId",
                table: "OrderModel");

            migrationBuilder.AddColumn<int>(
                name: "orderdItemId",
                table: "OrderModel",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "OrderModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_orderdItemId",
                table: "OrderModel",
                column: "orderdItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Items_orderdItemId",
                table: "OrderModel",
                column: "orderdItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "OrderModel",
                newName: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Items_orderdItemId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_orderdItemId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "orderdItemId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "orderdIteId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModel",
                table: "Orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_orderdIteId",
                table: "Orders",
                column: "orderdIteId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Items_orderdIteId",
                table: "Orders",
                column: "orderdIteId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderModel");
        }
    }
}
