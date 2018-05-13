using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Product.DataAccess.Migrations
{
    public partial class IntialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemDescription",
                columns: table => new
                {
                    ItemDescriptionId = table.Column<Guid>(nullable: false),
                    LongText = table.Column<string>(nullable: true),
                    ShortText = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDescription", x => x.ItemDescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "ItemPrice",
                columns: table => new
                {
                    ItemPriceId = table.Column<Guid>(nullable: false),
                    Value = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPrice", x => x.ItemPriceId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    DescriptionItemDescriptionId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PriceItemPriceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_ItemDescription_DescriptionItemDescriptionId",
                        column: x => x.DescriptionItemDescriptionId,
                        principalTable: "ItemDescription",
                        principalColumn: "ItemDescriptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_ItemPrice_PriceItemPriceId",
                        column: x => x.PriceItemPriceId,
                        principalTable: "ItemPrice",
                        principalColumn: "ItemPriceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_DescriptionItemDescriptionId",
                table: "Item",
                column: "DescriptionItemDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_PriceItemPriceId",
                table: "Item",
                column: "PriceItemPriceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ItemDescription");

            migrationBuilder.DropTable(
                name: "ItemPrice");
        }
    }
}
