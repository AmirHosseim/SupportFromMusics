using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuportFromMusics.Migrations
{
    public partial class NewMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicTexts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SingDetailId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "singer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_singer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "singType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_singType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuportForm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SingDetailId = table.Column<long>(type: "bigint", nullable: false),
                    SuportValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Suportedvalue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuportForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhonNumber = table.Column<long>(type: "bigint", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsFinishedSubName = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "singDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicTextId = table.Column<long>(type: "bigint", nullable: false),
                    SingerId = table.Column<int>(type: "int", nullable: false),
                    SuportId = table.Column<long>(type: "bigint", nullable: false),
                    singTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SharedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_singDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_singDetail_singer_SingerId",
                        column: x => x.SingerId,
                        principalTable: "singer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_singDetail_singType_singTypeId",
                        column: x => x.singTypeId,
                        principalTable: "singType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SingDetailId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    coment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sendTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coment_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowSingers",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SingerId = table.Column<long>(type: "bigint", nullable: false),
                    songerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowSingers", x => new { x.SingerId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FollowSingers_singer_songerId",
                        column: x => x.songerId,
                        principalTable: "singer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowSingers_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuportedUsers",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SuportFormId = table.Column<long>(type: "bigint", nullable: false),
                    SuportedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuportedUsers", x => new { x.UserId, x.SuportFormId });
                    table.ForeignKey(
                        name: "FK_SuportedUsers_SuportForm_SuportFormId",
                        column: x => x.SuportFormId,
                        principalTable: "SuportForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuportedUsers_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    SingDetailId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LikeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SingDetailId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => new { x.SingDetailId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Like_singDetail_SingDetailId1",
                        column: x => x.SingDetailId1,
                        principalTable: "singDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaveSing",
                columns: table => new
                {
                    SingDetailId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SingDetailId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveSing", x => new { x.SingDetailId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SaveSing_singDetail_SingDetailId1",
                        column: x => x.SingDetailId1,
                        principalTable: "singDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaveSing_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongVersies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextMusciId = table.Column<long>(type: "bigint", nullable: false),
                    SingDetailId = table.Column<long>(type: "bigint", nullable: false),
                    VersNumber = table.Column<int>(type: "int", nullable: false),
                    MusicTextId = table.Column<long>(type: "bigint", nullable: true),
                    SingDetailId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongVersies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongVersies_MusicTexts_MusicTextId",
                        column: x => x.MusicTextId,
                        principalTable: "MusicTexts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SongVersies_singDetail_SingDetailId1",
                        column: x => x.SingDetailId1,
                        principalTable: "singDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coment_UserId",
                table: "Coment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowSingers_songerId",
                table: "FollowSingers",
                column: "songerId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowSingers_UserId",
                table: "FollowSingers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_SingDetailId1",
                table: "Like",
                column: "SingDetailId1");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                table: "Like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SaveSing_SingDetailId1",
                table: "SaveSing",
                column: "SingDetailId1");

            migrationBuilder.CreateIndex(
                name: "IX_SaveSing_UserId",
                table: "SaveSing",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_singDetail_SingerId",
                table: "singDetail",
                column: "SingerId");

            migrationBuilder.CreateIndex(
                name: "IX_singDetail_singTypeId",
                table: "singDetail",
                column: "singTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersies_MusicTextId",
                table: "SongVersies",
                column: "MusicTextId");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersies_SingDetailId1",
                table: "SongVersies",
                column: "SingDetailId1");

            migrationBuilder.CreateIndex(
                name: "IX_SuportedUsers_SuportFormId",
                table: "SuportedUsers",
                column: "SuportFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coment");

            migrationBuilder.DropTable(
                name: "FollowSingers");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "SaveSing");

            migrationBuilder.DropTable(
                name: "SongVersies");

            migrationBuilder.DropTable(
                name: "SuportedUsers");

            migrationBuilder.DropTable(
                name: "MusicTexts");

            migrationBuilder.DropTable(
                name: "singDetail");

            migrationBuilder.DropTable(
                name: "SuportForm");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "singer");

            migrationBuilder.DropTable(
                name: "singType");
        }
    }
}
