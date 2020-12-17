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
    public class PhongChieuController : ControllerBase
    {
        private readonly DPContext _context;

        public PhongChieuController(DPContext context)
        {
            _context = context;
        }

        // GET: api/PhongChieu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhongChieuModel>>> GetPhongChieuModel()
        {
            return await _context.PhongChieuModel.ToListAsync();
        }

        // GET: api/PhongChieu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhongChieuModel>> GetPhongChieuModel(int id)
        {
            var phongChieuModel = await _context.PhongChieuModel.FindAsync(id);

            if (phongChieuModel == null)
            {
                return NotFound();
            }

            return phongChieuModel;
        }

        // PUT: api/PhongChieu/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhongChieuModel(int id, PhongChieuModel phongChieuModel)
        {
            if (id != phongChieuModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(phongChieuModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhongChieuModelExists(id))
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

        // POST: api/PhongChieu
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PhongChieuModel>> PostPhongChieuModel(PhongChieuModel phongChieuModel)
        {
            _context.PhongChieuModel.Add(phongChieuModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhongChieuModel", new { id = phongChieuModel.ID }, phongChieuModel);
        }

        // DELETE: api/PhongChieu/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhongChieuModel>> DeletePhongChieuModel(int id)
        {
            var phongChieuModel = await _context.PhongChieuModel.FindAsync(id);
            if (phongChieuModel == null)
            {
                return NotFound();
            }

            _context.PhongChieuModel.Remove(phongChieuModel);
            await _context.SaveChangesAsync();

            return phongChieuModel;
        }

        private bool PhongChieuModelExists(int id)
        {
            return _context.PhongChieuModel.Any(e => e.ID == id);
        }
    }
}
