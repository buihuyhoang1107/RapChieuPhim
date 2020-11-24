using Microsoft.EntityFrameworkCore.Migrations;

namespace RapChieuPhim.Migrations
{
    public partial class initinalcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiChuDePhim",
                columns: table => new
                {
                    idChuDe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenChuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trangThaiChuDe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiChuDePhim", x => x.idChuDe);
                });

            migrationBuilder.CreateTable(
                name: "Phim",
                columns: table => new
                {
                    idPhim = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenPhim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngayDang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    binhluanPhim = table.Column<int>(type: "int", nullable: false),
                    motaPhim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anhPhim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trangThaiPhim = table.Column<int>(type: "int", nullable: false),
                    idP_ChuDe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phim", x => x.idPhim);
                    table.ForeignKey(
                        name: "FK_Phim_LoaiChuDePhim_idP_ChuDe",
                        column: x => x.idP_ChuDe,
                        principalTable: "LoaiChuDePhim",
                        principalColumn: "idChuDe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phim_idP_ChuDe",
                table: "Phim",
                column: "idP_ChuDe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phim");

            migrationBuilder.DropTable(
                name: "LoaiChuDePhim");
        }
    }
}
