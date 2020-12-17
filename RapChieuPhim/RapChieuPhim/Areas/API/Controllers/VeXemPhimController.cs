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
    public class VeXemPhimController : ControllerBase
    {
        private readonly DPContext _context;

        public VeXemPhimController(DPContext context)
        {
            _context = context;
        }

        // GET: api/VeXemPhim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeXemPhimModel>>> GetVeXemPhimModel()
        {
            return await _context.VeXemPhimModel.ToListAsync();
        }

        // GET: api/VeXemPhim/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VeXemPhimModel>> GetVeXemPhimModel(int id)
        {
            var veXemPhimModel = await _context.VeXemPhimModel.FindAsync(id);

            if (veXemPhimModel == null)
            {
                return NotFound();
            }

            return veXemPhimModel;
        }

        // PUT: api/VeXemPhim/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeXemPhimModel(int id, VeXemPhimModel veXemPhimModel)
        {
            if (id != veXemPhimModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(veXemPhimModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeXemPhimModelExists(id))
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

        // POST: api/VeXemPhim
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VeXemPhimModel>> PostVeXemPhimModel(VeXemPhimModel veXemPhimModel)
        {
            _context.VeXemPhimModel.Add(veXemPhimModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeXemPhimModel", new { id = veXemPhimModel.ID }, veXemPhimModel);
        }

        // DELETE: api/VeXemPhim/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VeXemPhimModel>> DeleteVeXemPhimModel(int id)
        {
            var veXemPhimModel = await _context.VeXemPhimModel.FindAsync(id);
            if (veXemPhimModel == null)
            {
                return NotFound();
            }

            _context.VeXemPhimModel.Remove(veXemPhimModel);
            await _context.SaveChangesAsync();

            return veXemPhimModel;
        }

        private bool VeXemPhimModelExists(int id)
        {
            return _context.VeXemPhimModel.Any(e => e.ID == id);
        }
    }
}
