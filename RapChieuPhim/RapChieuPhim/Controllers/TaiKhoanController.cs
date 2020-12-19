using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RapChieuPhim.Areas.Admin.Models;
using RapChieuPhim.Areas.Admin.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace RapChieuPhim.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly DPContext _context;

        public TaiKhoanController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index() {
            return View();
        }
        public IActionResult Login([Bind("Ten_dang_nhap", "Mat_khau")] TaiKhoanModel taikhoan) {
            var r = _context.TaiKhoanModel.Where(m => (m.Ten_dang_nhap == taikhoan.Ten_dang_nhap && m.Mat_khau == StringProcessing.CreateMD5Hash(taikhoan.Mat_khau))).ToList();
            if (r.Count == 0) {
                return View("Error");
            }
            var str = JsonConvert.SerializeObject(taikhoan);
            HttpContext.Session.SetString("user", str);
            if (r[0].Loai_tai_khoan == "Quanly") {

                var url = Url.RouteUrl("areas", new { Controller = "Home", action = "Index", area = "admin" });
                return Redirect(url);
            }
            return RedirectToAction("Index", "Home");
        }



    }
}
