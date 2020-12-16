using Microsoft.EntityFrameworkCore.Migrations;

namespace RapChieuPhim.Migrations
{
    public partial class create1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BinhLuanModel_NguoiDungModel_ThanhVien_ID",
                table: "BinhLuanModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonModel_NguoiDungModel_ThanhVien_ID",
                table: "HoaDonModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "NguoiDungModel");

            migrationBuilder.RenameColumn(
                name: "ThanhVien_ID",
                table: "HoaDonModel",
                newName: "NguoiDung_ID");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDonModel_ThanhVien_ID",
                table: "HoaDonModel",
                newName: "IX_HoaDonModel_NguoiDung_ID");

            migrationBuilder.RenameColumn(
                name: "ThanhVien_ID",
                table: "BinhLuanModel",
                newName: "NguoiDung_ID");

            migrationBuilder.RenameIndex(
                name: "IX_BinhLuanModel_ThanhVien_ID",
                table: "BinhLuanModel",
                newName: "IX_BinhLuanModel_NguoiDung_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BinhLuanModel_NguoiDungModel_NguoiDung_ID",
                table: "BinhLuanModel",
                column: "NguoiDung_ID",
                principalTable: "NguoiDungModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonModel_NguoiDungModel_NguoiDung_ID",
                table: "HoaDonModel",
                column: "NguoiDung_ID",
                principalTable: "NguoiDungModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BinhLuanModel_NguoiDungModel_NguoiDung_ID",
                table: "BinhLuanModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonModel_NguoiDungModel_NguoiDung_ID",
                table: "HoaDonModel");

            migrationBuilder.RenameColumn(
                name: "NguoiDung_ID",
                table: "HoaDonModel",
                newName: "ThanhVien_ID");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDonModel_NguoiDung_ID",
                table: "HoaDonModel",
                newName: "IX_HoaDonModel_ThanhVien_ID");

            migrationBuilder.RenameColumn(
                name: "NguoiDung_ID",
                table: "BinhLuanModel",
                newName: "ThanhVien_ID");

            migrationBuilder.RenameIndex(
                name: "IX_BinhLuanModel_NguoiDung_ID",
                table: "BinhLuanModel",
                newName: "IX_BinhLuanModel_ThanhVien_ID");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "NguoiDungModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_BinhLuanModel_NguoiDungModel_ThanhVien_ID",
                table: "BinhLuanModel",
                column: "ThanhVien_ID",
                principalTable: "NguoiDungModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonModel_NguoiDungModel_ThanhVien_ID",
                table: "HoaDonModel",
                column: "ThanhVien_ID",
                principalTable: "NguoiDungModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
