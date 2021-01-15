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
    public class VeXemPhimController : Controller
    {
        private readonly DPContext _context;

        public VeXemPhimController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/VeXemPhim
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.VeXemPhimModel.Include(v => v.idGhe).Include(v => v.idHoaDon).Include(v => v.idPhim).Include(v => v.idPhongChieu).Include(v => v.idRapPhim).Include(v => v.idXuatChieu);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/VeXemPhim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veXemPhimModel = await _context.VeXemPhimModel
                .Include(v => v.idGhe)
                .Include(v => v.idHoaDon)
                .Include(v => v.idPhim)
                .Include(v => v.idPhongChieu)
                .Include(v => v.idRapPhim)
                .Include(v => v.idXuatChieu)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (veXemPhimModel == null)
            {
                return NotFound();
            }

            return View(veXemPhimModel);
        }

        // GET: Admin/VeXemPhim/Create
        public IActionResult Create()
        {
            ViewData["Ghe_ID"] = new SelectList(_context.GheModel, "ID", "ID");
            ViewData["HoaDon_ID"] = new SelectList(_context.HoaDonModel, "ID", "ID");
            ViewData["Phim_ID"] = new SelectList(_context.PhimModel, "ID", "ID");
            ViewData["PhongChieu_ID"] = new SelectList(_context.PhongChieuModel, "ID", "ID");
            ViewData["RapPhim_ID"] = new SelectList(_context.RapPhimModel, "ID", "ID");
            ViewData["XuatChieu_id"] = new SelectList(_context.XuatChieuModel, "ID", "ID");
            return View();
        }

        // POST: Admin/VeXemPhim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,XuatChieu_id,Ghe_ID,PhongChieu_ID,RapPhim_ID,Phim_ID,HoaDon_ID,DaXoa")] VeXemPhimModel veXemPhimModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veXemPhimModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Ghe_ID"] = new SelectList(_context.GheModel, "ID", "ID", veXemPhimModel.Ghe_ID);
            ViewData["HoaDon_ID"] = new SelectList(_context.HoaDonModel, "ID", "ID", veXemPhimModel.HoaDon_ID);
            ViewData["Phim_ID"] = new SelectList(_context.PhimModel, "ID", "ID", veXemPhimModel.Phim_ID);
            ViewData["PhongChieu_ID"] = new SelectList(_context.PhongChieuModel, "ID", "ID", veXemPhimModel.PhongChieu_ID);
            ViewData["RapPhim_ID"] = new SelectList(_context.RapPhimModel, "ID", "ID", veXemPhimModel.RapPhim_ID);
            ViewData["XuatChieu_id"] = new SelectList(_context.XuatChieuModel, "ID", "ID", veXemPhimModel.XuatChieu_id);
            return View(veXemPhimModel);
        }

        // GET: Admin/VeXemPhim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veXemPhimModel = await _context.VeXemPhimModel.FindAsync(id);
            if (veXemPhimModel == null)
            {
                return NotFound();
            }
            ViewData["Ghe_ID"] = new SelectList(_context.GheModel, "ID", "ID", veXemPhimModel.Ghe_ID);
            ViewData["HoaDon_ID"] = new SelectList(_context.HoaDonModel, "ID", "ID", veXemPhimModel.HoaDon_ID);
            ViewData["Phim_ID"] = new SelectList(_context.PhimModel, "ID", "ID", veXemPhimModel.Phim_ID);
            ViewData["PhongChieu_ID"] = new SelectList(_context.PhongChieuModel, "ID", "ID", veXemPhimModel.PhongChieu_ID);
            ViewData["RapPhim_ID"] = new SelectList(_context.RapPhimModel, "ID", "ID", veXemPhimModel.RapPhim_ID);
            ViewData["XuatChieu_id"] = new SelectList(_context.XuatChieuModel, "ID", "ID", veXemPhimModel.XuatChieu_id);
            return View(veXemPhimModel);
        }

        // POST: Admin/VeXemPhim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,XuatChieu_id,Ghe_ID,PhongChieu_ID,RapPhim_ID,Phim_ID,HoaDon_ID,DaXoa")] VeXemPhimModel veXemPhimModel)
        {
            if (id != veXemPhimModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veXemPhimModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeXemPhimModelExists(veXemPhimModel.ID))
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
            ViewData["Ghe_ID"] = new SelectList(_context.GheModel, "ID", "ID", veXemPhimModel.Ghe_ID);
            ViewData["HoaDon_ID"] = new SelectList(_context.HoaDonModel, "ID", "ID", veXemPhimModel.HoaDon_ID);
            ViewData["Phim_ID"] = new SelectList(_context.PhimModel, "ID", "ID", veXemPhimModel.Phim_ID);
            ViewData["PhongChieu_ID"] = new SelectList(_context.PhongChieuModel, "ID", "ID", veXemPhimModel.PhongChieu_ID);
            ViewData["RapPhim_ID"] = new SelectList(_context.RapPhimModel, "ID", "ID", veXemPhimModel.RapPhim_ID);
            ViewData["XuatChieu_id"] = new SelectList(_context.XuatChieuModel, "ID", "ID", veXemPhimModel.XuatChieu_id);
            return View(veXemPhimModel);
        }

        // GET: Admin/VeXemPhim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veXemPhimModel = await _context.VeXemPhimModel
                .Include(v => v.idGhe)
                .Include(v => v.idHoaDon)
                .Include(v => v.idPhim)
                .Include(v => v.idPhongChieu)
                .Include(v => v.idRapPhim)
                .Include(v => v.idXuatChieu)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (veXemPhimModel == null)
            {
                return NotFound();
            }

            return View(veXemPhimModel);
        }

        // POST: Admin/VeXemPhim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veXemPhimModel = await _context.VeXemPhimModel.FindAsync(id);
            _context.VeXemPhimModel.Remove(veXemPhimModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeXemPhimModelExists(int id)
        {
            return _context.VeXemPhimModel.Any(e => e.ID == id);
        }
    }
}
