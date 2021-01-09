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
        [HttpGet("size")]
        public async Task<int> GetSize()
        {
            return _context.PhimModel.Where(p => p.Da_xoa == false).ToList().Count;
        }

        // GET: api/Phim/a/b - a: index, b: range
        [HttpGet("page/{start}")]
        public async Task<ActionResult<IEnumerable<PhimModel>>> GetRange(int? start)
        {
            if (start == null || start <= 1) start = 0;
            else start -= 1;
            start = start * 16;
            List<PhimModel> data = _context.PhimModel.Where(p => p.Da_xoa == false).ToList();
            int end = 16;
            if (start + 16 > data.Count)
            {
                end = data.Count - (int)start ;
            }
            return data = data.GetRange((int)start, end);
        }

        // GET: api/Phim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhimModel>>> GetPhimModel()
        {
            return await _context.PhimModel.Where(p => p.Da_xoa == false).ToListAsync();
        }

        // GET: api/Phim
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
