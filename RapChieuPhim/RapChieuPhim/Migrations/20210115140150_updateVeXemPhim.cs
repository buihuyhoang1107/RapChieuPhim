using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RapChieuPhim.Migrations
{
    public partial class updateVeXemPhim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thoi_gian",
                table: "VeXemPhimModel");

            migrationBuilder.AddColumn<int>(
                name: "XuatChieu_id",
                table: "VeXemPhimModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VeXemPhimModel_XuatChieu_id",
                table: "VeXemPhimModel",
                column: "XuatChieu_id");

            migrationBuilder.AddForeignKey(
                name: "FK_VeXemPhimModel_XuatChieuModel_XuatChieu_id",
                table: "VeXemPhimModel",
                column: "XuatChieu_id",
                principalTable: "XuatChieuModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeXemPhimModel_XuatChieuModel_XuatChieu_id",
                table: "VeXemPhimModel");

            migrationBuilder.DropIndex(
                name: "IX_VeXemPhimModel_XuatChieu_id",
                table: "VeXemPhimModel");

            migrationBuilder.DropColumn(
                name: "XuatChieu_id",
                table: "VeXemPhimModel");

            migrationBuilder.AddColumn<DateTime>(
                name: "Thoi_gian",
                table: "VeXemPhimModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
