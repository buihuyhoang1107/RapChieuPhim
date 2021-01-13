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
    public class NguoiDungController : Controller
    {
        private readonly DPContext _context;

        public NguoiDungController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/NguoiDung
        public async Task<IActionResult> Index()
        {
            //var dstk = from nguoidung in _context.NguoiDungModel
            //           select nguoidung;
            //if (!String.IsNullOrWhiteSpace(ten))
            //{
            //    dstk = dstk.Where(s => s.HoTen.Contains(ten));
            //}
            //ViewBag.dstk = dstk;
            //return View();
            return View(await _context.NguoiDungModel.ToListAsync());
        }

        // GET: Admin/NguoiDung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDungModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return View(nguoiDungModel);
        }

        // GET: Admin/NguoiDung/Create
        [HttpGet]
        public IActionResult Create()
        {
            NguoiDungModel nguoiDung = new NguoiDungModel();
            return PartialView("_NguoiDungModelPartial", nguoiDung);
        }

        // POST: Admin/NguoiDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HoTen,Email,Dia_chi,Ngay_sinh,Sdt,Admin,Da_xoa")] NguoiDungModel nguoiDungModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiDungModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguoiDungModel);
        }

        // GET: Admin/NguoiDung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDungModel.FindAsync(id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }
            return View(nguoiDungModel);
            //var nguoidung = _context.NguoiDungModel.Where(x => x.ID == id).FirstOrDefault();
            //return PartialView("Edit", nguoidung);
        }

        // POST: Admin/NguoiDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HoTen,Email,Dia_chi,Ngay_sinh,Sdt,Admin,Da_xoa")] NguoiDungModel nguoiDungModel)
        {
            if (id != nguoiDungModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiDungModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiDungModelExists(nguoiDungModel.ID))
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
            return View(nguoiDungModel);
        }

        // GET: Admin/NguoiDung/Delete/5
        [HttpPost]
        public async Task<bool> Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }

            var nguoiDungModel = await _context.NguoiDungModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nguoiDungModel == null)
            {
                return false;
            }
            nguoiDungModel = await _context.NguoiDungModel.FindAsync(id);

            nguoiDungModel.Da_xoa = true;
            _context.NguoiDungModel.Update(nguoiDungModel);
            await _context.SaveChangesAsync();
            return true;
        }
        // GET: Admin/NguoiDung/DeleteALL/5

        [HttpPost]
        public async Task<bool> DeleteALL()
        {
            //var nguoiDungModel = from nguoidung in _context.NguoiDungModel
            //           select nguoidung;
            //if (nguoiDungModel == null)
            //{
            //    return false;
            //}
       

            //nguoiDungModel. = true;
            //_context.NguoiDungModel.Update(nguoiDungModel);
            //await _context.SaveChangesAsync();
            return true;
        }
        // GET: Admin/NguoiDung/Restore/5
        [HttpPost]
        public async Task<bool> Restore(int? id)
        {

            if (id == null)
            {
                return false;
            }

            var nguoiDungModel = await _context.NguoiDungModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nguoiDungModel == null)
            {
                return false;
            }
            nguoiDungModel = await _context.NguoiDungModel.FindAsync(id);

            nguoiDungModel.Da_xoa = false;
            _context.NguoiDungModel.Update(nguoiDungModel);
            await _context.SaveChangesAsync();
            return true;
        }

        //// POST: Admin/NguoiDung/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var nguoiDungModel = await _context.NguoiDungModel.FindAsync(id);
        //    _context.NguoiDungModel.Remove(nguoiDungModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool NguoiDungModelExists(int id)
        {
            return _context.NguoiDungModel.Any(e => e.ID == id);
        }
    }
}
