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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhimModel>>> GetPhimModel()
        {
            return await _context.PhimModel.ToListAsync();
        }

        // GET: api/Phim/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhimModel>> GetPhimModel(int id)
        {
            var phimModel = await _context.PhimModel.FindAsync(id);

            if (phimModel == null)
            {
                return NotFound();
            }

            return phimModel;
        }

        // PUT: api/Phim/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhimModel(int id, PhimModel phimModel)
        {
            if (id != phimModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(phimModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhimModelExists(id))
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

        // POST: api/Phim
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PhimModel>> PostPhimModel(PhimModel phimModel)
        {
            _context.PhimModel.Add(phimModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhimModel", new { id = phimModel.ID }, phimModel);
        }

        // DELETE: api/Phim/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhimModel>> DeletePhimModel(int id)
        {
            var phimModel = await _context.PhimModel.FindAsync(id);
            if (phimModel == null)
            {
                return NotFound();
            }

            _context.PhimModel.Remove(phimModel);
            await _context.SaveChangesAsync();

            return phimModel;
        }

        private bool PhimModelExists(int id)
        {
            return _context.PhimModel.Any(e => e.ID == id);
        }
    }
}
