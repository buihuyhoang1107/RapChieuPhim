using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapChieuPhim.Areas.Admin.Data;
using RapChieuPhim.Areas.Admin.Models;

namespace RapChieuPhim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LichChieuController : Controller
    {
        private readonly DPContext _context;

        public LichChieuController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/LichChieu
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.LichChieuModel.Include(l => l.idRapPhim);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/LichChieu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichChieuModel = await _context.LichChieuModel
                .Include(l => l.idRapPhim)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lichChieuModel == null)
            {
                return NotFound();
            }

            return View(lichChieuModel);
        }

        // GET: Admin/LichChieu/Create
        public IActionResult Create()
        {
            ViewData["RapPhim_ID"] = new SelectList(_context.Set<RapPhimModel>(), "ID", "ID");
            return View();
        }

        // POST: Admin/LichChieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ngay,Da_xoa,RapPhim_ID")] LichChieuModel lichChieuModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lichChieuModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RapPhim_ID"] = new SelectList(_context.Set<RapPhimModel>(), "ID", "ID", lichChieuModel.RapPhim_ID);
            return View(lichChieuModel);
        }

        // GET: Admin/LichChieu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichChieuModel = await _context.LichChieuModel.FindAsync(id);
            if (lichChieuModel == null)
            {
                return NotFound();
            }
            ViewData["RapPhim_ID"] = new SelectList(_context.Set<RapPhimModel>(), "ID", "ID", lichChieuModel.RapPhim_ID);
            return View(lichChieuModel);
        }

        // POST: Admin/LichChieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ngay,Da_xoa,RapPhim_ID")] LichChieuModel lichChieuModel)
        {
            if (id != lichChieuModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichChieuModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichChieuModelExists(lichChieuModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RapPhim_ID"] = new SelectList(_context.Set<RapPhimModel>(), "ID", "ID", lichChieuModel.RapPhim_ID);
            return View(lichChieuModel);
        }

        // GET: Admin/LichChieu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichChieuModel = await _context.LichChieuModel
                .Include(l => l.idRapPhim)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lichChieuModel == null)
            {
                return NotFound();
            }

            return View(lichChieuModel);
        }

        // POST: Admin/LichChieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lichChieuModel = await _context.LichChieuModel.FindAsync(id);
            _context.LichChieuModel.Remove(lichChieuModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LichChieuModelExists(int id)
        {
            return _context.LichChieuModel.Any(e => e.ID == id);
        }
    }
}
