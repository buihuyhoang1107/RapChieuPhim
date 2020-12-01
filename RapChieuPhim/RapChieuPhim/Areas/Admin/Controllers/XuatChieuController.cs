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
    public class XuatChieuController : Controller
    {
        private readonly DPContext _context;

        public XuatChieuController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/XuatChieu
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.XuatChieuModel.Include(x => x.idLichChieu).Include(x => x.idPhim);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/XuatChieu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xuatChieuModel = await _context.XuatChieuModel
                .Include(x => x.idLichChieu)
                .Include(x => x.idPhim)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (xuatChieuModel == null)
            {
                return NotFound();
            }

            return View(xuatChieuModel);
        }

        // GET: Admin/XuatChieu/Create
        public IActionResult Create()
        {
            ViewData["LichChieu_ID"] = new SelectList(_context.LichChieuModel, "ID", "ID");
            ViewData["Phim_ID"] = new SelectList(_context.PhimModel, "ID", "ID");
            return View();
        }

        // POST: Admin/XuatChieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Thoi_gian,Da_xoa,LichChieu_ID,Phim_ID")] XuatChieuModel xuatChieuModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xuatChieuModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LichChieu_ID"] = new SelectList(_context.LichChieuModel, "ID", "ID", xuatChieuModel.LichChieu_ID);
            ViewData["Phim_ID"] = new SelectList(_context.PhimModel, "ID", "ID", xuatChieuModel.Phim_ID);
            return View(xuatChieuModel);
        }

        // GET: Admin/XuatChieu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xuatChieuModel = await _context.XuatChieuModel.FindAsync(id);
            if (xuatChieuModel == null)
            {
                return NotFound();
            }
            ViewData["LichChieu_ID"] = new SelectList(_context.LichChieuModel, "ID", "ID", xuatChieuModel.LichChieu_ID);
            ViewData["Phim_ID"] = new SelectList(_context.PhimModel, "ID", "ID", xuatChieuModel.Phim_ID);
            return View(xuatChieuModel);
        }

        // POST: Admin/XuatChieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Thoi_gian,Da_xoa,LichChieu_ID,Phim_ID")] XuatChieuModel xuatChieuModel)
        {
            if (id != xuatChieuModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xuatChieuModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XuatChieuModelExists(xuatChieuModel.ID))
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
            ViewData["LichChieu_ID"] = new SelectList(_context.LichChieuModel, "ID", "ID", xuatChieuModel.LichChieu_ID);
            ViewData["Phim_ID"] = new SelectList(_context.PhimModel, "ID", "ID", xuatChieuModel.Phim_ID);
            return View(xuatChieuModel);
        }

        // GET: Admin/XuatChieu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xuatChieuModel = await _context.XuatChieuModel
                .Include(x => x.idLichChieu)
                .Include(x => x.idPhim)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (xuatChieuModel == null)
            {
                return NotFound();
            }

            return View(xuatChieuModel);
        }

        // POST: Admin/XuatChieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var xuatChieuModel = await _context.XuatChieuModel.FindAsync(id);
            _context.XuatChieuModel.Remove(xuatChieuModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XuatChieuModelExists(int id)
        {
            return _context.XuatChieuModel.Any(e => e.ID == id);
        }
    }
}
