using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RapChieuPhim.Areas.Admin.Data;

namespace RapChieuPhim.Areas.Admin.Models
{
    public static class SeedPhimData
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhimModel>().HasData(
                   new PhimModel
                   {
                       ID = 4,
                       Ten_phim = "Dekaranger 10 years after",
                       Hinh_anh = "",
                       Thoi_luong = 130,
                       Luot_xem = "3188",
                       Gia_ve = "50000",
                       Lich_Chieu = "2,4,6",
                       Da_xoa = 0,
                   },
                   new PhimModel
                   {
                       ID = 1,
                       Ten_phim = "Pacific Rim (2013)",
                       Hinh_anh = "",
                       Thoi_luong = 131,
                       Luot_xem = "2203",
                       Gia_ve = "80000",
                       Lich_Chieu = "5,6",
                       Da_xoa = 0,
                   },
                   new PhimModel
                   {
                       ID = 2,
                       Ten_phim = "Iron Man 3",
                       Hinh_anh = "",
                       Thoi_luong = 190,
                       Luot_xem = "5849",
                       Gia_ve = "100000",
                       Lich_Chieu = "2,3,5,7",
                       Da_xoa = 0,
                   },
                   new PhimModel
                   {
                       ID = 3,
                       Ten_phim = "Spider Man: Home Coming",
                       Hinh_anh = "",
                       Thoi_luong = 133,
                       Luot_xem = "1435",
                       Gia_ve = "55000",
                       Lich_Chieu = "4,6,CN",
                       Da_xoa = 0,
                   }
               );
        }
    }
}
