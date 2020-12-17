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
    public class XuatChieuController : ControllerBase
    {
        private readonly DPContext _context;

        public XuatChieuController(DPContext context)
        {
            _context = context;
        }

        // GET: api/XuatChieu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<XuatChieuModel>>> GetXuatChieuModel()
        {
            return await _context.XuatChieuModel.ToListAsync();
        }

        // GET: api/XuatChieu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<XuatChieuModel>> GetXuatChieuModel(int id)
        {
            var xuatChieuModel = await _context.XuatChieuModel.FindAsync(id);

            if (xuatChieuModel == null)
            {
                return NotFound();
            }

            return xuatChieuModel;
        }

        // PUT: api/XuatChieu/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXuatChieuModel(int id, XuatChieuModel xuatChieuModel)
        {
            if (id != xuatChieuModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(xuatChieuModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XuatChieuModelExists(id))
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

        // POST: api/XuatChieu
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<XuatChieuModel>> PostXuatChieuModel(XuatChieuModel xuatChieuModel)
        {
            _context.XuatChieuModel.Add(xuatChieuModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetXuatChieuModel", new { id = xuatChieuModel.ID }, xuatChieuModel);
        }

        // DELETE: api/XuatChieu/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<XuatChieuModel>> DeleteXuatChieuModel(int id)
        {
            var xuatChieuModel = await _context.XuatChieuModel.FindAsync(id);
            if (xuatChieuModel == null)
            {
                return NotFound();
            }

            _context.XuatChieuModel.Remove(xuatChieuModel);
            await _context.SaveChangesAsync();

            return xuatChieuModel;
        }

        private bool XuatChieuModelExists(int id)
        {
            return _context.XuatChieuModel.Any(e => e.ID == id);
        }
    }
}
