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
    public class ChuDePhimController : Controller
    {
        private readonly DPContext _context;

        public ChuDePhimController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/ChuDePhim
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiChuDePhim.ToListAsync());
        }

        // GET: Admin/ChuDePhim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuDePhimModel = await _context.LoaiChuDePhim
                .FirstOrDefaultAsync(m => m.idChuDe == id);
            if (chuDePhimModel == null)
            {
                return NotFound();
            }

            return View(chuDePhimModel);
        }

        // GET: Admin/ChuDePhim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChuDePhim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idChuDe,tenChuDe,trangThaiChuDe")] BinhLuanModel chuDePhimModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chuDePhimModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chuDePhimModel);
        }

        // GET: Admin/ChuDePhim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuDePhimModel = await _context.LoaiChuDePhim.FindAsync(id);
            if (chuDePhimModel == null)
            {
                return NotFound();
            }
            return View(chuDePhimModel);
        }

        // POST: Admin/ChuDePhim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idChuDe,tenChuDe,trangThaiChuDe")] BinhLuanModel chuDePhimModel)
        {
            if (id != chuDePhimModel.idChuDe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chuDePhimModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuDePhimModelExists(chuDePhimModel.idChuDe))
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
            return View(chuDePhimModel);
        }

        // GET: Admin/ChuDePhim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuDePhimModel = await _context.LoaiChuDePhim
                .FirstOrDefaultAsync(m => m.idChuDe == id);
            if (chuDePhimModel == null)
            {
                return NotFound();
            }

            return View(chuDePhimModel);
        }

        // POST: Admin/ChuDePhim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chuDePhimModel = await _context.LoaiChuDePhim.FindAsync(id);
            _context.LoaiChuDePhim.Remove(chuDePhimModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChuDePhimModelExists(int id)
        {
            return _context.LoaiChuDePhim.Any(e => e.idChuDe == id);
        }
    }
}
