using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapChieuPhim.Areas.Admin.Data;
using RapChieuPhim.Areas.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapChieuPhim.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DPContext _context;
        public LoginController(DPContext context)
        {
            _context = context;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
   
        // POST api/<LoginController>
        [HttpPost]
        public bool Post(Login value)
        {
            var tk = _context.TaiKhoanModel.FirstOrDefault(m => m.Ten_dang_nhap == value.username && m.Mat_khau == value.password && m.Loai_tai_khoan == 1);
            if (tk != null)
            {
                var str = JsonConvert.SerializeObject(tk);
                HttpContext.Session.SetString("tk", str);            
                return true;
            }
            return false;
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
