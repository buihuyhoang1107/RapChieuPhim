using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RapChieuPhim.Areas.Admin.Data;
using RapChieuPhim.Areas.Admin.Models;

namespace RapChieuPhim.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly DPContext _context;

        public NguoiDungController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
         public IActionResult Create()
        {
           
            var url = Url.RouteUrl("default", new { Controller = "TaiKhoan", action = "Index" });
            return Redirect(url);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HoTen,Email,Dia_chi,Ngay_sinh,Sdt,Admin,Da_xoa")] NguoiDungModel nguoiDungModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiDungModel);
                await _context.SaveChangesAsync();
                var url = Url.RouteUrl("default", new { Controller = "TaiKhoan", action = "Create" });
                return Redirect(url);
            }
            return View(nguoiDungModel);
        }

    }
 }
