using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Controllers
{
    public class ReviewsPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
