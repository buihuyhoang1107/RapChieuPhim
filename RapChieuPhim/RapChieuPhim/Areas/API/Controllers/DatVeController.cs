using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapChieuPhim.Areas.Admin.Data;
using RapChieuPhim.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatVeController : ControllerBase
    {
        public class request_model
        {
            public int phim_id { get; set; }
            public int xuatChieu_id { get; set; }
            public List<int> listGhe { get; set; }
        }

        private readonly DPContext _context;

        public DatVeController(DPContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<bool> Posttset([FromBody] request_model? req)
        {
            try
            {
                var phim = _context.PhimModel.FirstOrDefault(p => p.ID == req.phim_id);
                var xuatChieu = _context.XuatChieuModel.FirstOrDefault(x => x.ID == req.xuatChieu_id);
                string tongTien = (phim.Gia_ve * req.listGhe.Count).ToString();
                var nguoiDung = _context.NguoiDungModel.FirstOrDefault(n => n.ID == 1);
                var ngayLap = DateTime.Now;
                HoaDonModel hoaDonModel = new HoaDonModel
                {
                    Tong_tien = tongTien,
                    NguoiDung_ID = nguoiDung.ID,
                    Ngay_lap = ngayLap,
                    Da_xoa = false
                };

                _context.Add(hoaDonModel);
                _context.SaveChanges();

                var phongChieu = _context.PhongChieuModel.FirstOrDefault(p => p.ID == xuatChieu.PhongChieu_ID);
                var rapPhim = _context.RapPhimModel.FirstOrDefault(r => r.ID == phongChieu.RapPhim_ID);

                for (int i = 0; i < req.listGhe.Count; ++i)
                {
                    VeXemPhimModel veXemPhimModel = new VeXemPhimModel
                    {
                        Ghe_ID = req.listGhe[i],
                        PhongChieu_ID = phongChieu.ID,
                        RapPhim_ID = rapPhim.ID,
                        Phim_ID = phim.ID,
                        HoaDon_ID = hoaDonModel.ID,
                        DaXoa = false,
                        XuatChieu_id = xuatChieu.ID
                    };
                    _context.Add(veXemPhimModel);
                    _context.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
