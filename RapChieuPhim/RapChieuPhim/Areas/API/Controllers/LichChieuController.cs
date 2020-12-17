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

        // PUT: api/LichChieu/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLichChieuModel(int id, LichChieuModel lichChieuModel)
        {
            if (id != lichChieuModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(lichChieuModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichChieuModelExists(id))
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

        // POST: api/LichChieu
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LichChieuModel>> PostLichChieuModel(LichChieuModel lichChieuModel)
        {
            _context.LichChieuModel.Add(lichChieuModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLichChieuModel", new { id = lichChieuModel.ID }, lichChieuModel);
        }

        // DELETE: api/LichChieu/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LichChieuModel>> DeleteLichChieuModel(int id)
        {
            var lichChieuModel = await _context.LichChieuModel.FindAsync(id);
            if (lichChieuModel == null)
            {
                return NotFound();
            }

            _context.LichChieuModel.Remove(lichChieuModel);
            await _context.SaveChangesAsync();

            return lichChieuModel;
        }

        private bool LichChieuModelExists(int id)
        {
            return _context.LichChieuModel.Any(e => e.ID == id);
        }
    }
}
