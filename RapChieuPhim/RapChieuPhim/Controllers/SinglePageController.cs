using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Controllers
{
    public class SinglePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
