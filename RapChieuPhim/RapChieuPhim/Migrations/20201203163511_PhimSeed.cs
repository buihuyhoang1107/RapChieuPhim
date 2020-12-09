using Microsoft.EntityFrameworkCore.Migrations;

namespace RapChieuPhim.Migrations
{
    public partial class PhimSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.InsertData(
                table: "PhimModel",
                columns: new[] { "ID", "Da_xoa", "Gia_ve", "Hinh_anh", "Lich_Chieu", "Luot_xem", "Ten_phim", "Thoi_luong" },
                values: new object[,]
                {
                    { 4, 0, "50000", "", "2,4,6", "3188", "Dekaranger 10 years after", 130 },
                    { 1, 0, "80000", "", "5,6", "2203", "Pacific Rim (2013)", 131 },
                    { 2, 0, "100000", "", "2,3,5,7", "5849", "Iron Man 3", 190 },
                    { 3, 0, "55000", "", "4,6,CN", "1435", "Spider Man: Home Coming", 133 }
                });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "PhimModel",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhimModel",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhimModel",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhimModel",
                keyColumn: "ID",
                keyValue: 4);

        }
    }
}
