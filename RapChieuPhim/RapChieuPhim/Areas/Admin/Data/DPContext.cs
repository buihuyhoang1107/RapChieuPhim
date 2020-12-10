using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapChieuPhim.Areas.Admin.Models;

namespace RapChieuPhim.Areas.Admin.Data
{
    public class DPContext : DbContext
    {
        public DPContext(DbContextOptions<DPContext> options) : base(options)
        {

        }
        public DbSet<RapChieuPhim.Areas.Admin.Models.TaiKhoanModel> TaiKhoanModel { get; set; }
        public DbSet<RapChieuPhim.Areas.Admin.Models.BinhLuanModel> BinhLuanModel { get; set; }
        public DbSet<RapChieuPhim.Areas.Admin.Models.GheModel> GheModel { get; set; }
        public DbSet<RapChieuPhim.Areas.Admin.Models.HoaDonModel> HoaDonModel { get; set; }
        public DbSet<RapChieuPhim.Areas.Admin.Models.LichChieuModel> LichChieuModel { get; set; }
        public DbSet<RapChieuPhim.Areas.Admin.Models.NguoiDungModel> NguoiDungModel { get; set; }
        public DbSet<RapChieuPhim.Areas.Admin.Models.PhimModel> PhimModel { get; set; }
        public DbSet<RapChieuPhim.Areas.Admin.Models.PhongChieuModel> PhongChieuModel { get; set; }
        public DbSet<RapChieuPhim.Areas.Admin.Models.RapPhimModel> RapPhimModel { get; set; }
        public DbSet<RapChieuPhim.Areas.Admin.Models.VeXemPhimModel> VeXemPhimModel { get; set; }
        public DbSet<RapChieuPhim.Areas.Admin.Models.XuatChieuModel> XuatChieuModel { get; set; }

    }
}
