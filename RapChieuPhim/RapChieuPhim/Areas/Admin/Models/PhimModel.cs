using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class PhimModel
    {
        [Key]
        public int ID { get; set; }
        public string Ten_phim { get; set; }
        public string Hinh_anh { get; set; }
        public int Thoi_luong { get; set; }
        public string Luot_xem { get; set; }
        public string Gia_ve { get; set; }
        public string Lich_Chieu { get; set; }
        public int Da_xoa { get; set; }

        public ICollection<XuatChieuModel> lstXuatChieu { get; set; }
        public ICollection<VeXemPhimModel> lstVeXemPhim { get; set; }
        public ICollection<BinhLuanModel> lstBinhLuan { get; set; }

    }
}
