using Microsoft.AspNetCore.Mvc;
using RapChieuPhim.Areas.Admin.Data;
using RapChieuPhim.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Controllers
{
    public class BooksStickerController : Controller
    {
        private readonly DPContext _context;

        public BooksStickerController(DPContext context)
        {
            _context = context;
        }

        public IActionResult Index([FromQuery] int? phim_id)
        {

            if (phim_id == null) phim_id = _context.PhimModel.FirstOrDefault(p => p.Da_xoa == false).ID;

            var phim_selected = (PhimModel)_context.PhimModel.FirstOrDefault(p => p.ID == phim_id);
            ViewBag.Phim = phim_selected;
            ViewBag.ListPhim = _context.PhimModel.Where(p => p.Da_xoa == false).ToList();

            //lấy dang sách rap coi chiếu phim có id == phim_id
            var rapPhim = _context.RapPhimModel.Where(
                r => _context.LichChieuModel.Where(
                    l => _context.XuatChieuModel.Where(
                        x => x.Phim_ID == phim_id)
                        .Select(x => x.LichChieu_ID)
                        .Contains(l.ID))
                    .Select(l => l.RapPhim_ID)
                    .Contains(r.ID) && r.Da_xoa == false).ToList();
            ViewBag.RapPhim = rapPhim;

            var lichChieu = _context.LichChieuModel
                .Where(l => l.RapPhim_ID == rapPhim[0].ID
                && l.Da_xoa == false
                && _context.XuatChieuModel
                .Where(x => x.Phim_ID == phim_selected.ID
                && x.Da_xoa == false)
                .Select(x => x.LichChieu_ID)
                .Contains(l.ID)).ToList();
            ViewBag.LichChieu = lichChieu;

            ViewBag.XuatChieu = (from xuat in _context.XuatChieuModel
                                 join lich in _context.LichChieuModel on xuat.LichChieu_ID equals lich.ID
                                 join rap in _context.RapPhimModel on lich.RapPhim_ID equals rap.ID
                                 where xuat.Phim_ID == phim_id
                                 && xuat.Da_xoa == false
                                 && lich.Da_xoa == false
                                 && rap.Da_xoa == false
                                 && rap.ID == rapPhim[0].ID
                                 && lich.ID == lichChieu[0].ID
                                 select xuat).ToList();
            return View();
        }
    }
}
