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

namespace RapChieuPhim.Controllers
{
    public class HomeController : Controller
    {
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
    }
}

