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
    public class RapPhimController : Controller
    {
        private readonly DPContext _context;

        public RapPhimController(DPContext context)
        {
            _context = context;
        }

        public void Test()
        {
            Console.WriteLine("awdawdwadwafshjvsukayfr");
        }

        // GET: Admin/RapPhim
        public async Task<IActionResult> Index()
        {
            return View(await _context.RapPhimModel.ToListAsync());
        }

        // GET: Admin/RapPhim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapPhimModel = await _context.RapPhimModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rapPhimModel == null)
            {
                return NotFound();
            }

            return View(rapPhimModel);
        }

        // GET: Admin/RapPhim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RapPhim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ten_rap,Dia_chi,Da_xoa")] RapPhimModel rapPhimModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapPhimModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rapPhimModel);
        }

        // GET: Admin/RapPhim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapPhimModel = await _context.RapPhimModel.FindAsync(id);
            if (rapPhimModel == null)
            {
                return NotFound();
            }
            return View(rapPhimModel);
        }

        // POST: Admin/RapPhim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ten_rap,Dia_chi,Da_xoa")] RapPhimModel rapPhimModel)
        {
            if (id != rapPhimModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapPhimModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapPhimModelExists(rapPhimModel.ID))
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
            return View(rapPhimModel);
        }

        // GET: Admin/RapPhim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapPhimModel = await _context.RapPhimModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rapPhimModel == null)
            {
                return NotFound();
            }

            return await DeleteConfirmed(rapPhimModel.ID);
        }

        // POST: Admin/RapPhim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var rapPhimModel = await _context.RapPhimModel.FindAsync(id);
            rapPhimModel.Da_xoa = true;
            _context.RapPhimModel.Update(rapPhimModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapPhimModelExists(int id)
        {
            return _context.RapPhimModel.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapPhimModel = await _context.RapPhimModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rapPhimModel == null)
            {
                return NotFound();
            }

            return await RestoreConfirmed(rapPhimModel.ID);
        }

        // POST: Admin/RapPhim/Restore/5
        [HttpPost, ActionName("Restore")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreConfirmed(int? id)
        {
            var rapPhimModel = await _context.RapPhimModel.FindAsync(id);
            rapPhimModel.Da_xoa = false;
            _context.RapPhimModel.Update(rapPhimModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Test")]
        [ValidateAntiForgeryToken]
        public async void TestConfirmed(int? id)
        {
            Console.WriteLine("oki !");
        }
    }
}
