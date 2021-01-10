using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapChieuPhim.Areas.Admin.Data;
using RapChieuPhim.Areas.Admin.Models;

namespace RapChieuPhim.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhimController : ControllerBase
    {
        private readonly DPContext _context;

        public PhimController(DPContext context)
        {
            _context = context;
        }

        // GET: api/Phim
        [HttpGet("size")]
        public async Task<int> GetSize()
        {
            return _context.PhimModel.Where(p => p.Da_xoa == false).ToList().Count;
        }

        // GET: api/Phim/a/b - a: index, b: range
        [HttpGet("page/{start}")]
        public async Task<ActionResult<IEnumerable<PhimModel>>> GetRange(int? start)
        {
            if (start == null || start <= 1) start = 0;
            else start -= 1;
            start = start * 16;
            List<PhimModel> data = _context.PhimModel.Where(p => p.Da_xoa == false).ToList();
            int end = 16;
            if (start + 16 > data.Count)
            {
                end = data.Count - (int)start;
            }
            data = data.GetRange((int)start, end);
            if (data.Count() == 0)
                return NotFound();

            return data;
        }

        // GET: api/Phim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhimModel>>> GetPhimModel()
        {
            return await _context.PhimModel.Where(p => p.Da_xoa == false).ToListAsync();
        }

        // GET: api/Phim
        [HttpGet("{id}")]
        public async Task<ActionResult<PhimModel>> GetPhimModel(int id)
        {
            var phimModel = await _context.PhimModel.FindAsync(id);
            phimModel.Luot_xem += 1;
            _context.SaveChangesAsync();
            if (phimModel == null)
            {
                return NotFound();
            }

            return phimModel;
        }

        [HttpGet("View/{id}")]
        public async Task<ActionResult<int>> increaseView(int id)
        {
            var phimModel = await _context.PhimModel.FindAsync(id);
            phimModel.Luot_xem += 1;
            _context.SaveChangesAsync();
            if (phimModel == null)
            {
                return NotFound();
            }

            return phimModel.Luot_xem;
        }

        private bool PhimModelExists(int id)
        {
            return _context.PhimModel.Any(e => e.ID == id);
        }
    }
}
