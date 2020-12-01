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
    public class BinhLuanController : Controller
    {
        private readonly DPContext _context;

        public BinhLuanController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/BinhLuan
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.BinhLuanModel.Include(b => b.idPhim).Include(b => b.idThanhVien);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/BinhLuan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuanModel = await _context.BinhLuanModel
                .Include(b => b.idPhim)
                .Include(b => b.idThanhVien)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (binhLuanModel == null)
            {
                return NotFound();
            }

            return View(binhLuanModel);
        }

        // GET: Admin/BinhLuan/Create
        public IActionResult Create()
        {
            ViewData["Phim_ID"] = new SelectList(_context.Set<PhimModel>(), "ID", "ID");
            ViewData["ThanhVien_ID"] = new SelectList(_context.Set<ThanhVienModel>(), "ID", "Discriminator");
            return View();
        }

        // POST: Admin/BinhLuan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ThanhVien_ID,Phim_ID,Noi_dung")] BinhLuanModel binhLuanModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(binhLuanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Phim_ID"] = new SelectList(_context.Set<PhimModel>(), "ID", "ID", binhLuanModel.Phim_ID);
            ViewData["ThanhVien_ID"] = new SelectList(_context.Set<ThanhVienModel>(), "ID", "Discriminator", binhLuanModel.ThanhVien_ID);
            return View(binhLuanModel);
        }

        // GET: Admin/BinhLuan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuanModel = await _context.BinhLuanModel.FindAsync(id);
            if (binhLuanModel == null)
            {
                return NotFound();
            }
            ViewData["Phim_ID"] = new SelectList(_context.Set<PhimModel>(), "ID", "ID", binhLuanModel.Phim_ID);
            ViewData["ThanhVien_ID"] = new SelectList(_context.Set<ThanhVienModel>(), "ID", "Discriminator", binhLuanModel.ThanhVien_ID);
            return View(binhLuanModel);
        }

        // POST: Admin/BinhLuan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ThanhVien_ID,Phim_ID,Noi_dung")] BinhLuanModel binhLuanModel)
        {
            if (id != binhLuanModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binhLuanModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinhLuanModelExists(binhLuanModel.ID))
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
            ViewData["Phim_ID"] = new SelectList(_context.Set<PhimModel>(), "ID", "ID", binhLuanModel.Phim_ID);
            ViewData["ThanhVien_ID"] = new SelectList(_context.Set<ThanhVienModel>(), "ID", "Discriminator", binhLuanModel.ThanhVien_ID);
            return View(binhLuanModel);
        }

        // GET: Admin/BinhLuan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuanModel = await _context.BinhLuanModel
                .Include(b => b.idPhim)
                .Include(b => b.idThanhVien)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (binhLuanModel == null)
            {
                return NotFound();
            }

            return View(binhLuanModel);
        }

        // POST: Admin/BinhLuan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var binhLuanModel = await _context.BinhLuanModel.FindAsync(id);
            _context.BinhLuanModel.Remove(binhLuanModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhLuanModelExists(int id)
        {
            return _context.BinhLuanModel.Any(e => e.ID == id);
        }
    }
}
