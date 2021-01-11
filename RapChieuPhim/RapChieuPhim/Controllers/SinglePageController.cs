using Microsoft.AspNetCore.Mvc;
using RapChieuPhim.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapChieuPhim.Areas.Admin.Models;

namespace RapChieuPhim.Controllers
{
    public class SinglePageController : Controller
    {
        private readonly DPContext _context;

        public SinglePageController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index([FromQuery] int? page)
        {
            
            if (page == null) page = _context.PhimModel.FirstOrDefault(p => p.Da_xoa == false).ID;

            ViewBag.Phim = (PhimModel)_context.PhimModel.FirstOrDefault(p => p.ID == page);
            return View();
        }
    }
}
