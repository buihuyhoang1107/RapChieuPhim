using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RapChieuPhim.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("tk") == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Home", area = "Admin" });
            }
            JObject us = JObject.Parse(HttpContext.Session.GetString("tk"));
            TaiKhoanModel taiKhoanModel = new TaiKhoanModel();
            taiKhoanModel.Ten_dang_nhap = us.SelectToken("Ten_dang_nhap").ToString();
            
            return View(taiKhoanModel);
        }
        public ActionResult Login()
        {
            return View();
        }
  
    }
}
