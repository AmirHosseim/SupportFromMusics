using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuportFromMusics.Migrations
{
    public partial class ChangeComentModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Coment",
                table: "Coment");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Coment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coment",
                table: "Coment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Coment_UserId",
                table: "Coment",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Coment",
                table: "Coment");

            migrationBuilder.DropIndex(
                name: "IX_Coment_UserId",
                table: "Coment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Coment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coment",
                table: "Coment",
                columns: new[] { "UserId", "SingDetailId" });
        }
    }
}
