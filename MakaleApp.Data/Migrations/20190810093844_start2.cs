using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MakaleApp.Data.Migrations
{
    public partial class start2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(maxLength: 128, nullable: true),
                    UpdatedUserId = table.Column<string>(maxLength: 128, nullable: true),
                    KategoriId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KategoriAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Makale",
                columns: table => new
                {
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(maxLength: 128, nullable: true),
                    UpdatedUserId = table.Column<string>(maxLength: 128, nullable: true),
                    MakaleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Baslik = table.Column<string>(nullable: true),
                    Icerik = table.Column<string>(nullable: true),
                    KategoriId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makale", x => x.MakaleId);
                    table.ForeignKey(
                        name: "FK_Makale_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorum",
                columns: table => new
                {
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<string>(maxLength: 128, nullable: true),
                    UpdatedUserId = table.Column<string>(maxLength: 128, nullable: true),
                    YorumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    YorumIcerik = table.Column<string>(nullable: true),
                    MakaleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorum", x => x.YorumId);
                    table.ForeignKey(
                        name: "FK_Yorum_Makale_MakaleId",
                        column: x => x.MakaleId,
                        principalTable: "Makale",
                        principalColumn: "MakaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Makale_KategoriId",
                table: "Makale",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_MakaleId",
                table: "Yorum",
                column: "MakaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yorum");

            migrationBuilder.DropTable(
                name: "Makale");

            migrationBuilder.DropTable(
                name: "Kategori");
        }
    }
}
