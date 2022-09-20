using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuportFromMusics.Migrations
{
    public partial class ChangeComentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "coment",
                table: "Coment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "sendTime",
                table: "Coment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coment",
                table: "Coment");

            migrationBuilder.DropColumn(
                name: "sendTime",
                table: "Coment");
        }
    }
}
