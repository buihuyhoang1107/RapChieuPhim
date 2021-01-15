using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RapChieuPhim.Models;
using Microsoft.Data.SqlClient;
using RapChieuPhim.Areas.Admin.Data;
using RapChieuPhim.Areas.Admin.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RapChieuPhim.Controllers
{
    public class HomeController : Controller
    {
        private readonly DPContext _context;

        public HomeController (DPContext context)
        {
            _context = context;
        }
        public IActionResult Index( )
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("taikhoan")))
            {
                JObject us = JObject.Parse(HttpContext.Session.GetString("taikhoan"));
                TaiKhoanModel taiKhoan = new TaiKhoanModel();
                taiKhoan.Ten_dang_nhap = us.SelectToken("Ten_dang_nhap").ToString();
                taiKhoan.Mat_khau = us.SelectToken("Mat_khau").ToString();
                return View(taiKhoan);
            }
            else
                return View();
         
        }
        public IActionResult logout([Bind("Ten_dang_nhap", "Mat_khau")] TaiKhoanModel taikhoan)
        {

            var r = _context.TaiKhoanModel.Where(m => (m.Ten_dang_nhap =="" && m.Mat_khau == "")).ToList();
            if (r.Count == 0)
            {
                return View("Index");
            }
            var str = JsonConvert.SerializeObject(taikhoan);
            HttpContext.Session.SetString("taikhoan", str);
            if (r[0].Loai_tai_khoan == "Vip")
            {

                var url = Url.RouteUrl("areas", new { Controller = "Home", action = "Index", area = "admin" });
                return Redirect(url);
            }
            return RedirectToAction("Index", "Home");
        }
       
    }
}

