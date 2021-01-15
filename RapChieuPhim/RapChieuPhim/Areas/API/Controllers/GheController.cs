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
    public class GheController : ControllerBase
    {
        private readonly DPContext _context;

        public GheController(DPContext context)
        {
            _context = context;
        }

        // GET: api/Ghe/Rap/1
        [HttpGet("phim/{phim_id}/xuat/{xuat_id}")]
        public async Task<ActionResult<IEnumerable<GheModel>>> GetGheModel_r_x(int? phim_id, int? xuat_id)
        {
            if (xuat_id == null || phim_id == null)
            {
                return NotFound();
            }
            return await _context.GheModel
                .Where(g => _context.XuatChieuModel
                .Where(x => x.ID == xuat_id
                    && x.Phim_ID == phim_id
                    && x.Da_xoa == false).Select(x => x.PhongChieu_ID).Contains(g.PhongChieu_ID)).ToListAsync();
        }

        // GET: api/Ghe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GheModel>>> GetGheModel()
        {
            return await _context.GheModel.ToListAsync();
        }

        // GET: api/Ghe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GheModel>> GetGheModel(int id)
        {
            var gheModel = await _context.GheModel.FindAsync(id);

            if (gheModel == null)
            {
                return NotFound();
            }

            return gheModel;
        }

        // PUT: api/Ghe/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGheModel(int id, GheModel gheModel)
        {
            if (id != gheModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(gheModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GheModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ghe
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GheModel>> PostGheModel(GheModel gheModel)
        {
            _context.GheModel.Add(gheModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGheModel", new { id = gheModel.ID }, gheModel);
        }

        // DELETE: api/Ghe/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GheModel>> DeleteGheModel(int id)
        {
            var gheModel = await _context.GheModel.FindAsync(id);
            if (gheModel == null)
            {
                return NotFound();
            }

            _context.GheModel.Remove(gheModel);
            await _context.SaveChangesAsync();

            return gheModel;
        }

        private bool GheModelExists(int id)
        {
            return _context.GheModel.Any(e => e.ID == id);
        }
    }
}
