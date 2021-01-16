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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RapChieuPhim.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly DPContext _context;

        public TaiKhoanController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Ten_dang_nhap", "Mat_khau")] TaiKhoanModel taikhoan)
        {

            var r = _context.TaiKhoanModel.Where(m => (m.Ten_dang_nhap == taikhoan.Ten_dang_nhap && m.Mat_khau == StringProcessing.CreateMD5Hash(taikhoan.Mat_khau))).ToList();
            if (r.Count == 0)
            {
                return View("Index");
            }
            var str = JsonConvert.SerializeObject(taikhoan);
            HttpContext.Session.SetString("taikhoan", str);
            if (r[0].Loai_tai_khoan == 1)
            {

                var url = Url.RouteUrl("areas", new { Controller = "Home", action = "Index", area = "admin" });
                return Redirect(url);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Create()
        {
            ViewData["NguoiDung_ID"] = new SelectList(_context.NguoiDungModel, "ID", "HoTen");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ten_dang_nhap,Mat_khau,Loai_tai_khoan,NguoiDung_ID,Da_xoa")] TaiKhoanModel taiKhoanModel)
        {

            if (ModelState.IsValid)
            {
                taiKhoanModel.Mat_khau = StringProcessing.CreateMD5Hash(taiKhoanModel.Mat_khau);
                _context.Add(taiKhoanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NguoiDung_ID"] = new SelectList(_context.NguoiDungModel, "ID", "ID", taiKhoanModel.NguoiDung_ID);
            return View(taiKhoanModel);
        }


    }
}
