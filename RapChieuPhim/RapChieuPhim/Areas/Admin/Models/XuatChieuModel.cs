using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class XuatChieuModel
    {
        [Key]
        public int ID { get; set; }
        [DataType(DataType.Time)]
        public string Thoi_gian { get; set; }
        public bool Da_xoa { get; set; }
        public int LichChieu_ID { get; set; }
        public int Phim_ID { get; set; }

        [ForeignKey("Phim_ID")]
        public virtual PhimModel idPhim { get; set; }
        [ForeignKey("LichChieu_ID")]
        public virtual LichChieuModel idLichChieu { get; set; }
    }
}
