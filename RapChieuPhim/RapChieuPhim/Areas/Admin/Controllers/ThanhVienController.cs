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
    public class ThanhVienController : Controller
    {
        private readonly DPContext _context;

        public ThanhVienController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/ThanhVienModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThanhVienModel.ToListAsync());
        }

        // GET: Admin/ThanhVienModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhVienModel = await _context.ThanhVienModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (thanhVienModel == null)
            {
                return NotFound();
            }

            return View(thanhVienModel);
        }

        // GET: Admin/ThanhVienModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ThanhVienModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HoTe,Email,Dia_chi,Ngay_sinh,Sdt,Admin,Da_xoa")] ThanhVienModel thanhVienModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thanhVienModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thanhVienModel);
        }

        // GET: Admin/ThanhVienModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhVienModel = await _context.ThanhVienModel.FindAsync(id);
            if (thanhVienModel == null)
            {
                return NotFound();
            }
            return View(thanhVienModel);
        }

        // POST: Admin/ThanhVienModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HoTe,Email,Dia_chi,Ngay_sinh,Sdt,Admin,Da_xoa")] ThanhVienModel thanhVienModel)
        {
            if (id != thanhVienModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thanhVienModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThanhVienModelExists(thanhVienModel.ID))
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
            return View(thanhVienModel);
        }

        // GET: Admin/ThanhVienModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhVienModel = await _context.ThanhVienModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (thanhVienModel == null)
            {
                return NotFound();
            }

            return View(thanhVienModel);
        }

        // POST: Admin/ThanhVienModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thanhVienModel = await _context.ThanhVienModel.FindAsync(id);
            _context.ThanhVienModel.Remove(thanhVienModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThanhVienModelExists(int id)
        {
            return _context.ThanhVienModel.Any(e => e.ID == id);
        }
    }
}
