using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapChieuPhim.Areas.Admin.Data;
using RapChieuPhim.Areas.Admin.Models;

namespace RapChieuPhim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaiKhoanController : Controller
    {
        private readonly DPContext _context;

        public TaiKhoanController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/TaiKhoan
        public async Task<IActionResult> Index(String ten)
        {
            if (HttpContext.Session.GetString("tk") == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Home", area = "Admin" });
            }
            var dstk = from taikhoan in _context.TaiKhoanModel
                       select taikhoan;
            if (!String.IsNullOrWhiteSpace(ten))
            {
                dstk = dstk.Where(s => s.Ten_dang_nhap.Contains(ten));
            }
            //var dstk = (from s in _context.TaiKhoanModel
            //            join c in _context.NguoiDungModel on s.NguoiDung_ID equals c.ID
            //            select s).ToList();

            ViewBag.dstk = dstk;
            return View();

            // var dPContext = _context.TaiKhoanModel.Include(t => t.NguoiDungModel);
            //return View(await dPContext.ToListAsync());
        }

        // GET: Admin/TaiKhoan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("tk") == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Home", area = "Admin" });
            }
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoanModel = await _context.TaiKhoanModel
                .Include(t => t.NguoiDungModel)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (taiKhoanModel == null)
            {
                return NotFound();
            }

            return View(taiKhoanModel);
        }

        // GET: Admin/TaiKhoan/Create
        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("tk") == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Home", area = "Admin" });
            }
            TaiKhoanModel taiKhoan = new TaiKhoanModel();

            ViewBag.lstTaiKhoan = from l in _context.NguoiDungModel                            
                                  select l;
            ViewData["NguoiDung_ID"] = new SelectList(_context.NguoiDungModel, "ID", "ID");
            return View();
        }


        // POST: Admin/TaiKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ten_dang_nhap,Mat_khau,Loai_tai_khoan,NguoiDung_ID,Da_xoa")] TaiKhoanModel taiKhoanModel)
        {
            if (HttpContext.Session.GetString("tk") == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Home", area = "Admin" });
            }
            if (ModelState.IsValid)
            {
                _context.Add(taiKhoanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NguoiDung_ID"] = new SelectList(_context.NguoiDungModel, "ID", "ID", taiKhoanModel.NguoiDung_ID);
            return View(taiKhoanModel);
        }

        // GET: Admin/TaiKhoan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("tk") == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Home", area = "Admin" });
            }
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoanModel = await _context.TaiKhoanModel.FindAsync(id);
            if (taiKhoanModel == null)
            {
                return NotFound();
            }
            ViewBag.lstTaiKhoan = from l in _context.NguoiDungModel
                                  select l;
          
            ViewData["NguoiDung_ID"] = new SelectList(_context.NguoiDungModel, "ID", "ID", taiKhoanModel.NguoiDung_ID);
            return View(taiKhoanModel);
        }

        // POST: Admin/TaiKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ten_dang_nhap,Mat_khau,Loai_tai_khoan,NguoiDung_ID,Da_xoa")] TaiKhoanModel taiKhoanModel)
        {
            if (HttpContext.Session.GetString("tk") == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Home", area = "Admin" });
            }
            if (id != taiKhoanModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiKhoanModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiKhoanModelExists(taiKhoanModel.ID))
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
            ViewData["NguoiDung_ID"] = new SelectList(_context.NguoiDungModel, "ID", "ID", taiKhoanModel.NguoiDung_ID);
            return View(taiKhoanModel);
        }

        // GET: Admin/TaiKhoan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("tk") == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Home", area = "Admin" });
            }
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoanModel = await _context.TaiKhoanModel
                .Include(t => t.NguoiDungModel)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (taiKhoanModel == null)
            {
                return NotFound();
            }

            return View(taiKhoanModel);
        }

        // POST: Admin/TaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("tk") == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Home", area = "Admin" });
            }
            var taiKhoanModel = await _context.TaiKhoanModel.FindAsync(id);
            _context.TaiKhoanModel.Remove(taiKhoanModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiKhoanModelExists(int id)
        {
            return _context.TaiKhoanModel.Any(e => e.ID == id);
        }
    }
}
