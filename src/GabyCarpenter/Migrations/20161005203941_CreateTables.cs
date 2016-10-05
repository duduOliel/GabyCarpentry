using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GabyCarpenter.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    color = table.Column<string>(nullable: true),
                    depth = table.Column<float>(nullable: false),
                    description = table.Column<string>(maxLength: 600, nullable: true),
                    height = table.Column<float>(nullable: false),
                    images = table.Column<byte[]>(nullable: true),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    price = table.Column<int>(nullable: false),
                    width = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemModelid = table.Column<int>(nullable: true),
                    text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tag_items_ItemModelid",
                        column: x => x.ItemModelid,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    ItemModelid = table.Column<int>(nullable: true),
                    amountInInvetory = table.Column<int>(nullable: false),
                    partNumber = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false),
                    provider = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.id);
                    table.ForeignKey(
                        name: "FK_parts_items_ItemModelid",
                        column: x => x.ItemModelid,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ItemModelid",
                table: "Tag",
                column: "ItemModelid");

            migrationBuilder.CreateIndex(
                name: "IX_parts_ItemModelid",
                table: "parts",
                column: "ItemModelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "parts");

            migrationBuilder.DropTable(
                name: "items");
        }
    }
}
