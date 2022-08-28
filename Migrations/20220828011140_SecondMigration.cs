using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendTest.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemEntity_Carts_CartId",
                table: "ItemEntity");

            migrationBuilder.DropIndex(
                name: "IX_ItemEntity_CartId",
                table: "ItemEntity");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "ItemEntity");

            migrationBuilder.CreateTable(
                name: "ItemCartEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCartEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCartEntity_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCartEntity_ItemEntity_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCartEntity_CartId",
                table: "ItemCartEntity",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCartEntity_ItemId",
                table: "ItemCartEntity",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCartEntity");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "ItemEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemEntity_CartId",
                table: "ItemEntity",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemEntity_Carts_CartId",
                table: "ItemEntity",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
