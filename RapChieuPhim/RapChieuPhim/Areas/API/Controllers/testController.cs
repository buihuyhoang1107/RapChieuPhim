using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapChieuPhim.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        public class test
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<int> Arr { get; set; }
        }

        private readonly DPContext _context;

        public testController(DPContext context)
        {
            _context = context;
        }

        // GET: api/Home
        [HttpPost]
        public ActionResult<bool> Posttset([FromBody] test? t)
        {
            return false;
        }
    }
}
