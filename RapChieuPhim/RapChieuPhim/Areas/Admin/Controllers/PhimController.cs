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
    public class PhimController : Controller
    {
        private readonly DPContext _context;

        public PhimController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Phim
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhimModel.ToListAsync());
        }

        // GET: Admin/Phim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phimModel = await _context.PhimModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (phimModel == null)
            {
                return NotFound();
            }

            return View(phimModel);
        }

        // GET: Admin/Phim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Phim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ten_phim,Hinh_anh,Video,Thoi_luong,Luot_xem,Gia_ve,Da_xoa")] PhimModel phimModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phimModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phimModel);
        }

        // GET: Admin/Phim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phimModel = await _context.PhimModel.FindAsync(id);
            if (phimModel == null)
            {
                return NotFound();
            }
            return View(phimModel);
        }

        // POST: Admin/Phim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ten_phim,Hinh_anh,Video,Thoi_luong,Luot_xem,Gia_ve,Da_xoa")] PhimModel phimModel)
        {
            if (id != phimModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phimModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhimModelExists(phimModel.ID))
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
            return View(phimModel);
        }

        // GET: Admin/Phim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phimModel = await _context.PhimModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (phimModel == null)
            {
                return NotFound();
            }

            return View(phimModel);
        }

        // POST: Admin/Phim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phimModel = await _context.PhimModel.FindAsync(id);
            _context.PhimModel.Remove(phimModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhimModelExists(int id)
        {
            return _context.PhimModel.Any(e => e.ID == id);
        }
    }
}
