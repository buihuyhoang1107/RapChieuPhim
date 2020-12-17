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

        // PUT: api/RapPhim
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRapPhimModel(int id, RapPhimModel rapPhimModel)
        {
            if (id != rapPhimModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(rapPhimModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RapPhimModelExists(id))
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

        // POST: api/RapPhim
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RapPhimModel>> PostRapPhimModel(RapPhimModel rapPhimModel)
        {
            _context.RapPhimModel.Add(rapPhimModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRapPhimModel", new { id = rapPhimModel.ID }, rapPhimModel);
        }

        // DELETE: api/RapPhim/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RapPhimModel>> DeleteRapPhimModel(int id)
        {
            var rapPhimModel = await _context.RapPhimModel.FindAsync(id);
            if (rapPhimModel == null)
            {
                return NotFound();
            }

            _context.RapPhimModel.Remove(rapPhimModel);
            await _context.SaveChangesAsync();

            return rapPhimModel;
        }

        private bool RapPhimModelExists(int id)
        {
            return _context.RapPhimModel.Any(e => e.ID == id);
        }
    }
}
