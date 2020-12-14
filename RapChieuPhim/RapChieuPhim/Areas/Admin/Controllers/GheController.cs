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
    public class GheController : Controller
    {
        private int Idselect = -1;

        private readonly DPContext _context;

        public GheController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Ghe/
        public async Task<IActionResult> Index(int? id)
        {
            var dPContext = _context.GheModel.Include(g => g.idPhongChieu);
            if (id == null)
            {
                if (this.Idselect == -1)
                {
                    return NotFound();
                }
                return View(await dPContext.Where(g => g.PhongChieu_ID == this.Idselect).ToListAsync());
            }

            var phongChieuModel = await _context.PhongChieuModel
                .Include(p => p.idRapPhim)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (phongChieuModel == null)
            {
                return NotFound();
            }

            this.Idselect = (int)id;

            return View(await dPContext.Where(g => g.PhongChieu_ID == id).ToListAsync());
        }

        // GET: Admin/Ghe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gheModel = await _context.GheModel
                .Include(g => g.idPhongChieu)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gheModel == null)
            {
                return NotFound();
            }

            return View(gheModel);
        }

        // GET: Admin/Ghe/Create
        public IActionResult Create()
        {
            ViewBag.listPhong = _context.PhongChieuModel.ToList();
            ViewData["PhongChieu_ID"] = new SelectList(_context.Set<PhongChieuModel>(), "ID", "ID");
            return View();
        }

        // POST: Admin/Ghe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ten,Loai,Da_chon,Da_xoa,PhongChieu_ID")] GheModel gheModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gheModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhongChieu_ID"] = new SelectList(_context.Set<PhongChieuModel>(), "ID", "ID", gheModel.PhongChieu_ID);
            return View(gheModel);
        }

        // GET: Admin/Ghe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gheModel = await _context.GheModel.FindAsync(id);
            if (gheModel == null)
            {
                return NotFound();
            }
            ViewData["PhongChieu_ID"] = new SelectList(_context.Set<PhongChieuModel>(), "ID", "ID", gheModel.PhongChieu_ID);
            return View(gheModel);
        }

        // POST: Admin/Ghe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ten,Loai,Da_chon,Da_xoa,PhongChieu_ID")] GheModel gheModel)
        {
            if (id != gheModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gheModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GheModelExists(gheModel.ID))
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
            ViewData["PhongChieu_ID"] = new SelectList(_context.Set<PhongChieuModel>(), "ID", "ID", gheModel.PhongChieu_ID);
            return View(gheModel);
        }

        // POST: Admin/Ghe/Delete/5
        [HttpPost]
        public async Task<bool> Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }

            var gheModel = await _context.GheModel
                .Include(g => g.idPhongChieu)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gheModel == null)
            {
                return false;
            }
            gheModel = await _context.GheModel.FindAsync(id);
            gheModel.Da_xoa = true;
            _context.GheModel.Update(gheModel);
            await _context.SaveChangesAsync();
            return true;
        }

        //// POST: Admin/Ghe/Delete/5
        //[HttpPost, ActionName("Delete")]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var gheModel = await _context.GheModel.FindAsync(id);
        //    gheModel.Da_xoa = true;
        //    _context.GheModel.Update(gheModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}


        // POST: Admin/Ghe/Delete/5
        [HttpPost]
        public async Task<bool> Restore(int? id)
        {
            if (id == null)
            {
                return false;
            }

            var gheModel = await _context.GheModel
                .Include(g => g.idPhongChieu)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gheModel == null)
            {
                return false;
            }

            //neu phong da bi xoa thi khong cho khoi phuc ghe
            var phongChieu = await _context.PhongChieuModel.FirstOrDefaultAsync(p => p.ID == gheModel.PhongChieu_ID);
            if (phongChieu.Da_xoa)
            {
                return false;
            }

            gheModel = await _context.GheModel.FindAsync(id);
            gheModel.Da_xoa = false;
            _context.GheModel.Update(gheModel);
            await _context.SaveChangesAsync();
            return true;
        }

        //// POST: Admin/Ghe/Delete/5
        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> RestoreConfirmed(int id)
        //{
        //    var gheModel = await _context.GheModel.FindAsync(id);
        //    gheModel.Da_xoa = false;
        //    _context.GheModel.Update(gheModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool GheModelExists(int id)
        {
            return _context.GheModel.Any(e => e.ID == id);
        }
    }
}
