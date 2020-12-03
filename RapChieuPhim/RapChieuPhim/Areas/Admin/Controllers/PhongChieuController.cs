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
    public class PhongChieuController : Controller
    {
        private int Idselect = -1;

        private readonly DPContext _context;

        public PhongChieuController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/PhongChieu
        public async Task<IActionResult> Index(int? id)
        {
            var dPContext = _context.PhongChieuModel.Include(p => p.idRapPhim);
            if (id == null)
            {
                if (this.Idselect == -1)
                {
                    return NotFound();
                }
                return View(await dPContext.Where(p => p.RapPhim_ID == this.Idselect).ToListAsync());
            }

            var phongChieuModel = await _context.PhongChieuModel
                .Include(p => p.idRapPhim)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (phongChieuModel == null)
            {
                return NotFound();
            }
            this.Idselect = (int)id;
            return View(await dPContext.Where(p => p.RapPhim_ID == id).ToListAsync());
        }

        // GET: Admin/PhongChieu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongChieuModel = await _context.PhongChieuModel
                .Include(p => p.idRapPhim)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (phongChieuModel == null)
            {
                return NotFound();
            }

            return View(phongChieuModel);
        }

        // GET: Admin/PhongChieu/Create
        public IActionResult Create()
        {
            ViewBag.listRap = _context.RapPhimModel.ToList();
            ViewData["RapPhim_ID"] = new SelectList(_context.Set<RapPhimModel>(), "ID", "ID");
            return View();
        }

        // POST: Admin/PhongChieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ten_Phong,Da_xoa,RapPhim_ID")] PhongChieuModel phongChieuModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongChieuModel);
                await _context.SaveChangesAsync();
                for (int j = 0; j < 90; ++j)
                {
                    GheModel ghe = new GheModel();
                    ghe.Da_xoa = false;
                    ghe.Da_chon = false;
                    ghe.Ten = (char)((j / 10) + 'A') + (j % 10).ToString();
                    if ((j / 10 >= 2)
                        && (j / 10 <= 6)
                        && (j % 10 >= 2)
                        && (j % 10 <= 7))
                    {
                        ghe.Loai = 1;
                    }
                    else
                    {
                        ghe.Loai = 0;
                    }

                    ghe.PhongChieu_ID = phongChieuModel.ID;
                    _context.GheModel.Add(ghe);
                    await _context.SaveChangesAsync();
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RapPhim_ID"] = new SelectList(_context.Set<RapPhimModel>(), "ID", "ID", phongChieuModel.RapPhim_ID);
            return View(phongChieuModel);
        }

        // GET: Admin/PhongChieu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongChieuModel = await _context.PhongChieuModel.FindAsync(id);
            if (phongChieuModel == null)
            {
                return NotFound();
            }
            ViewData["RapPhim_ID"] = new SelectList(_context.Set<RapPhimModel>(), "ID", "ID", phongChieuModel.RapPhim_ID);
            return View(phongChieuModel);
        }

        // POST: Admin/PhongChieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ten_Phong,Da_xoa,RapPhim_ID")] PhongChieuModel phongChieuModel)
        {
            if (id != phongChieuModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongChieuModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongChieuModelExists(phongChieuModel.ID))
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
            ViewData["RapPhim_ID"] = new SelectList(_context.Set<RapPhimModel>(), "ID", "ID", phongChieuModel.RapPhim_ID);
            return View(phongChieuModel);
        }

        // GET: Admin/PhongChieu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongChieuModel = await _context.PhongChieuModel
                .Include(p => p.idRapPhim)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (phongChieuModel == null)
            {
                return NotFound();
            }

            return await DeleteConfirmed(phongChieuModel.ID);
        }

        // POST: Admin/PhongChieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phongChieuModel = await _context.PhongChieuModel.FindAsync(id);
            phongChieuModel.Da_xoa = true;
            _context.PhongChieuModel.Update(phongChieuModel);
            var listGhe = _context.GheModel.Where(ghe => ghe.PhongChieu_ID == id);
            foreach (var ghe in listGhe)
            {
                ghe.Da_xoa = true;
            }
            _context.GheModel.UpdateRange(listGhe.ToArray());
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongChieuModelExists(int id)
        {
            return _context.PhongChieuModel.Any(e => e.ID == id);
        }

        // GET: Admin/PhongChieu/Restore/5
        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongChieuModel = await _context.PhongChieuModel
                .Include(p => p.idRapPhim)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (phongChieuModel == null)
            {
                return NotFound();
            }

            return await RestoreConfirmed(phongChieuModel.ID);
        }

        // POST: Admin/PhongChieu/Restore/5
        [HttpPost, ActionName("Restore")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreConfirmed(int id)
        {
            var phongChieuModel = await _context.PhongChieuModel.FindAsync(id);
            if (phongChieuModel.idRapPhim.Da_xoa)
            {
                return RedirectToAction(nameof(Index));
            }

            phongChieuModel.Da_xoa = false;
            _context.PhongChieuModel.Update(phongChieuModel);
            var listGhe = _context.GheModel.Where(ghe => ghe.PhongChieu_ID == id);
            foreach (var ghe in listGhe)
            {
                ghe.Da_xoa = false;
            }
            _context.GheModel.UpdateRange(listGhe.ToArray());
            _context.PhongChieuModel.Update(phongChieuModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
