﻿using System;
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
    public class HoaDonController : ControllerBase
    {
        private readonly DPContext _context;

        public HoaDonController(DPContext context)
        {
            _context = context;
        }

        // GET: api/HoaDon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDonModel>>> GetHoaDonModel()
        {
            return await _context.HoaDonModel.ToListAsync();
        }

        // GET: api/HoaDon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDonModel>> GetHoaDonModel(int id)
        {
            var hoaDonModel = await _context.HoaDonModel.FindAsync(id);

            if (hoaDonModel == null)
            {
                return NotFound();
            }

            return hoaDonModel;
        }

        // PUT: api/HoaDon/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoaDonModel(int id, HoaDonModel hoaDonModel)
        {
            if (id != hoaDonModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(hoaDonModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonModelExists(id))
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

        // POST: api/HoaDon
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HoaDonModel>> PostHoaDonModel(HoaDonModel hoaDonModel)
        {
            _context.HoaDonModel.Add(hoaDonModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoaDonModel", new { id = hoaDonModel.ID }, hoaDonModel);
        }

        // DELETE: api/HoaDon/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HoaDonModel>> DeleteHoaDonModel(int id)
        {
            var hoaDonModel = await _context.HoaDonModel.FindAsync(id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }

            _context.HoaDonModel.Remove(hoaDonModel);
            await _context.SaveChangesAsync();

            return hoaDonModel;
        }

        private bool HoaDonModelExists(int id)
        {
            return _context.HoaDonModel.Any(e => e.ID == id);
        }
    }
}
