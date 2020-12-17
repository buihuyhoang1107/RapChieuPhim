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
    public class TaiKhoanController : ControllerBase
    {
        private readonly DPContext _context;

        public TaiKhoanController(DPContext context)
        {
            _context = context;
        }

        // GET: api/TaiKhoan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiKhoanModel>>> GetTaiKhoanModel()
        {
            return await _context.TaiKhoanModel.ToListAsync();
        }

        // GET: api/TaiKhoan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoanModel>> GetTaiKhoanModel(int id)
        {
            var taiKhoanModel = await _context.TaiKhoanModel.FindAsync(id);

            if (taiKhoanModel == null)
            {
                return NotFound();
            }

            return taiKhoanModel;
        }

        // PUT: api/TaiKhoan/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaiKhoanModel(int id, TaiKhoanModel taiKhoanModel)
        {
            if (id != taiKhoanModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(taiKhoanModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiKhoanModelExists(id))
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

        // POST: api/TaiKhoan
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaiKhoanModel>> PostTaiKhoanModel(TaiKhoanModel taiKhoanModel)
        {
            _context.TaiKhoanModel.Add(taiKhoanModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaiKhoanModel", new { id = taiKhoanModel.ID }, taiKhoanModel);
        }

        // DELETE: api/TaiKhoan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaiKhoanModel>> DeleteTaiKhoanModel(int id)
        {
            var taiKhoanModel = await _context.TaiKhoanModel.FindAsync(id);
            if (taiKhoanModel == null)
            {
                return NotFound();
            }

            _context.TaiKhoanModel.Remove(taiKhoanModel);
            await _context.SaveChangesAsync();

            return taiKhoanModel;
        }

        private bool TaiKhoanModelExists(int id)
        {
            return _context.TaiKhoanModel.Any(e => e.ID == id);
        }
    }
}
