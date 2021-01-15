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
    public class RapPhimController : ControllerBase
    {
        private readonly DPContext _context;

        public RapPhimController(DPContext context)
        {
            _context = context;
        }

        // GET: api/RapPhim/phim/1
        [HttpGet("phim/{phim_id}")]
        public async Task<ActionResult<IEnumerable<RapPhimModel>>> GetRapPhimModel_Phim(int? phim_id)
        {
            if (phim_id == null) return null;
            var data = await _context.RapPhimModel.Where(
                r => _context.LichChieuModel.Where(
                    l => _context.XuatChieuModel.Where(
                        x => x.Phim_ID == phim_id)
                        .Select(x => x.LichChieu_ID)
                        .Contains(l.ID))
                    .Select(l => l.RapPhim_ID)
                    .Contains(r.ID) && r.Da_xoa == false).ToListAsync();
            if (data.Count == 0) return null;
            return data;
        }

        // GET: api/RapPhim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RapPhimModel>>> GetRapPhimModel()
        {
            return await _context.RapPhimModel.ToListAsync();
        }

        // GET: api/RapPhim/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RapPhimModel>> GetRapPhimModel(int id)
        {
            var rapPhimModel = await _context.RapPhimModel.FindAsync(id);

            if (rapPhimModel == null)
            {
                return NotFound();
            }

            return rapPhimModel;
        }

        private bool RapPhimModelExists(int id)
        {
            return _context.RapPhimModel.Any(e => e.ID == id);
        }
    }
}
