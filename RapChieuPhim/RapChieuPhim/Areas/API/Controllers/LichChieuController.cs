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
    public class LichChieuController : ControllerBase
    {
        private readonly DPContext _context;

        public LichChieuController(DPContext context)
        {
            _context = context;
        }

        // GET: api/LichChieu/phim/7/rap/1
        [HttpGet("phim/{phim_id}/Rap/{rap_id}")]
        public async Task<ActionResult<IEnumerable<LichChieuModel>>> GetLichChieuModel_p_r(int? phim_id, int? rap_id)
        {
            //var rapPhim = await _context.RapPhimModel.Where(
            //      r => _context.LichChieuModel.Where(
            //          l => _context.XuatChieuModel.Where(
            //              x => x.Phim_ID == phim_id)
            //              .Select(x => x.LichChieu_ID)
            //              .Contains(l.ID))
            //          .Select(l => l.RapPhim_ID)
            //          .Contains(r.ID) && r.Da_xoa == false && r.ID == rap_id).ToListAsync();

            //var data = await _context.LichChieuModel
            //       .Where(l => rapPhim.Select(r => r.ID)
            //       .Contains(l.RapPhim_ID)
            //       && _context.XuatChieuModel.Where(x => x.Phim_ID == phim_id).Select(x => x.LichChieu_ID).Contains(l.ID)
            //       && l.Da_xoa == false).ToListAsync();

            var data = await _context.LichChieuModel
                .Where(l => l.RapPhim_ID == rap_id
                    && _context.XuatChieuModel
                .Where(x => x.Da_xoa == false
                    && x.LichChieu_ID == l.ID
                    && x.Phim_ID == phim_id)
                .Select(x => x.LichChieu_ID)
                .Contains(l.ID)
                    && l.Da_xoa == false).ToListAsync();

            return data;
        }


        // GET: api/LichChieu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LichChieuModel>>> GetLichChieuModel()
        {
            return await _context.LichChieuModel.ToListAsync();
        }

        // GET: api/LichChieu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LichChieuModel>> GetLichChieuModel(int id)
        {
            var lichChieuModel = await _context.LichChieuModel.FindAsync(id);

            if (lichChieuModel == null)
            {
                return NotFound();
            }

            return lichChieuModel;
        }

        private bool LichChieuModelExists(int id)
        {
            return _context.LichChieuModel.Any(e => e.ID == id);
        }
    }
}
