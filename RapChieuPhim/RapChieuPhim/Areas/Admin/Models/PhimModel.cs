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
        public string Video { get; set; } //them moi
        public int Thoi_luong { get; set; }
        public int Luot_xem { get; set; } // string -> int
        public int Gia_ve { get; set; }// string -> int
        //public string Lich_Chieu { get; set; }
        public bool Da_xoa { get; set; } //int -> bool

        public ICollection<XuatChieuModel> lstXuatChieu { get; set; }
        public ICollection<VeXemPhimModel> lstVeXemPhim { get; set; }
        public ICollection<BinhLuanModel> lstBinhLuan { get; set; }

    }
}
