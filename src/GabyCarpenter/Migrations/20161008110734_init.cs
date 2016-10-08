using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GabyCarpenter.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(nullable: true),
                    Depth = table.Column<float>(nullable: false),
                    Description = table.Column<string>(maxLength: 600, nullable: true),
                    Height = table.Column<float>(nullable: false),
                    Images = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Width = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountInInvetory = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    IsInvenory = table.Column<bool>(nullable: false),
                    ItemModelId = table.Column<int>(nullable: true),
                    Length = table.Column<float>(nullable: false),
                    PartNumber = table.Column<string>(nullable: true),
                    PartPrice = table.Column<int>(nullable: false),
                    Provider = table.Column<string>(nullable: true),
                    Thickness = table.Column<float>(nullable: false),
                    Width = table.Column<float>(nullable: false),
                    WoodType = table.Column<int>(nullable: true),
                    Material = table.Column<int>(nullable: true),
                    PlateMaterial = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Part_Items_ItemModelId",
                        column: x => x.ItemModelId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemModelId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Items_ItemModelId",
                        column: x => x.ItemModelId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Part_ItemModelId",
                table: "Part",
                column: "ItemModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ItemModelId",
                table: "Tag",
                column: "ItemModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
