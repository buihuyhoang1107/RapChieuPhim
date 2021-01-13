using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Controllers
{
    public class VideosPageController : Controller
    {
        public IActionResult Index([FromQuery] int? page)
        {
            if (page == null) page = 1;
            ViewData["PageId"] = page;
            return View();
        }
    }
}
