using Microsoft.EntityFrameworkCore.Migrations;

namespace PostgresPlayGround.Migrations
{
    public partial class nullableColorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Colors_ColorId",
                table: "Goods");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Goods",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Colors_ColorId",
                table: "Goods",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Colors_ColorId",
                table: "Goods");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Goods",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Colors_ColorId",
                table: "Goods",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
