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
                for (int i = 0; i < 3; ++i)
                {
                    PhongChieuModel phongChieu = new PhongChieuModel();
                    phongChieu.Da_xoa = false;
                    phongChieu.Ten_Phong = "P" + i.ToString();
                    phongChieu.RapPhim_ID = rapPhimModel.ID;
                    _context.PhongChieuModel.Add(phongChieu);
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

                        ghe.PhongChieu_ID = phongChieu.ID;
                        _context.GheModel.Add(ghe);
                        await _context.SaveChangesAsync();
                    }
                }
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

        // POST: Admin/RapPhim/Delete/5
        [HttpPost]
        public async Task<bool> Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }

            var rapPhimModel = await _context.RapPhimModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rapPhimModel == null)
            {
                return false;
            }

            rapPhimModel = await _context.RapPhimModel.FindAsync(id);
            rapPhimModel.Da_xoa = true;
            _context.RapPhimModel.Update(rapPhimModel);
            var listPhong = _context.PhongChieuModel.Where(phong => phong.RapPhim_ID == id);
            foreach (var phong in listPhong)
            {
                phong.Da_xoa = true;
                var listGhe = _context.GheModel.Where(ghe => ghe.PhongChieu_ID == phong.ID);
                foreach (var ghe in listGhe)
                {
                    ghe.Da_xoa = true;
                }
                _context.GheModel.UpdateRange(listGhe.ToArray());
            }
            _context.PhongChieuModel.UpdateRange(listPhong.ToArray());
            await _context.SaveChangesAsync();
            return true;
        }

        // POST: Admin/RapPhim/Restore/5
        [HttpPost]
        public async Task<bool> Restore(int? id)
        {
            if (id == null)
            {
                return false;
            }

            var rapPhimModel = await _context.RapPhimModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rapPhimModel == null)
            {
                return false;
            }

            rapPhimModel = await _context.RapPhimModel.FindAsync(id);
            rapPhimModel.Da_xoa = false;
            _context.RapPhimModel.Update(rapPhimModel);
            var listPhong = _context.PhongChieuModel.Where(phong => phong.RapPhim_ID == id);
            foreach (var phong in listPhong)
            {
                phong.Da_xoa = false;

                var listGhe = _context.GheModel.Where(ghe => ghe.PhongChieu_ID == phong.ID);
                foreach (var ghe in listGhe)
                {
                    ghe.Da_xoa = false;
                }
                _context.GheModel.UpdateRange(listGhe.ToArray());

            }
            _context.PhongChieuModel.UpdateRange(listPhong.ToArray());
            await _context.SaveChangesAsync();
            return true;
        }

        private bool RapPhimModelExists(int id)
        {
            return _context.RapPhimModel.Any(e => e.ID == id);
        }
    }
}
