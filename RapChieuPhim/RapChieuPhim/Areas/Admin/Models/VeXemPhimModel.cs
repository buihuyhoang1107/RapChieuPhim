using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class VeXemPhimModel
    {
        [Key]
        public int ID { get; set; }
       
        
        [DataType(DataType.Time)]
        public DateTime Thoi_gian { get; set; }

        public int? Ghe_ID { get; set; }
        [ForeignKey("Ghe_ID")]
        public virtual GheModel idGhe { get; set; }

        public int? RapPhim_ID { get; set; }
        [ForeignKey("RapPhim_ID")]
        public virtual RapPhimModel idRapPhim { get; set; }

        public int? Phim_ID { get; set; }
        [ForeignKey("Phim_ID")]
        public virtual PhimModel idPhim { get; set; }

        public int? HoaDon_ID { get; set; }
        [ForeignKey("HoaDon_ID")]
        public virtual HoaDonModel idHoaDon { get; set; }

        public bool DaXoa { get; set; }

    }
}
