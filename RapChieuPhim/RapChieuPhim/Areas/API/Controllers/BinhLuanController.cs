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
    public class BinhLuanController : ControllerBase
    {
        private readonly DPContext _context;

        public BinhLuanController(DPContext context)
        {
            _context = context;
        }

        // GET: api/BinhLuan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BinhLuanModel>>> GetBinhLuanModel()
        {
            return await _context.BinhLuanModel.ToListAsync();
        }

        // GET: api/BinhLuan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BinhLuanModel>> GetBinhLuanModel(int id)
        {
            var binhLuanModel = await _context.BinhLuanModel.FindAsync(id);

            if (binhLuanModel == null)
            {
                return NotFound();
            }

            return binhLuanModel;
        }

        // PUT: api/BinhLuan/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBinhLuanModel(int id, BinhLuanModel binhLuanModel)
        {
            if (id != binhLuanModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(binhLuanModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BinhLuanModelExists(id))
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

        // POST: api/BinhLuan
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BinhLuanModel>> PostBinhLuanModel(BinhLuanModel binhLuanModel)
        {
            _context.BinhLuanModel.Add(binhLuanModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBinhLuanModel", new { id = binhLuanModel.ID }, binhLuanModel);
        }

        // DELETE: api/BinhLuan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BinhLuanModel>> DeleteBinhLuanModel(int id)
        {
            var binhLuanModel = await _context.BinhLuanModel.FindAsync(id);
            if (binhLuanModel == null)
            {
                return NotFound();
            }

            _context.BinhLuanModel.Remove(binhLuanModel);
            await _context.SaveChangesAsync();

            return binhLuanModel;
        }

        private bool BinhLuanModelExists(int id)
        {
            return _context.BinhLuanModel.Any(e => e.ID == id);
        }
    }
}
