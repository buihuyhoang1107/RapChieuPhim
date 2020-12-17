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
    public class NguoiDungController : ControllerBase
    {
        private readonly DPContext _context;

        public NguoiDungController(DPContext context)
        {
            _context = context;
        }

        // GET: api/NguoiDung
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguoiDungModel>>> GetNguoiDungModel()
        {
            return await _context.NguoiDungModel.ToListAsync();
        }

        // GET: api/NguoiDung/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NguoiDungModel>> GetNguoiDungModel(int id)
        {
            var nguoiDungModel = await _context.NguoiDungModel.FindAsync(id);

            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return nguoiDungModel;
        }

        // PUT: api/NguoiDung/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoiDungModel(int id, NguoiDungModel nguoiDungModel)
        {
            if (id != nguoiDungModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(nguoiDungModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDungModelExists(id))
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

        // POST: api/NguoiDung
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NguoiDungModel>> PostNguoiDungModel(NguoiDungModel nguoiDungModel)
        {
            _context.NguoiDungModel.Add(nguoiDungModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNguoiDungModel", new { id = nguoiDungModel.ID }, nguoiDungModel);
        }

        // DELETE: api/NguoiDung/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NguoiDungModel>> DeleteNguoiDungModel(int id)
        {
            var nguoiDungModel = await _context.NguoiDungModel.FindAsync(id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            _context.NguoiDungModel.Remove(nguoiDungModel);
            await _context.SaveChangesAsync();

            return nguoiDungModel;
        }

        private bool NguoiDungModelExists(int id)
        {
            return _context.NguoiDungModel.Any(e => e.ID == id);
        }
    }
}
