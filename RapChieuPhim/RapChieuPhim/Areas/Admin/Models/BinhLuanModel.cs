using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class BinhLuanModel
    {

        [Key]
        public int ID { get; set; }
        public int ThanhVien_ID { get; set; }
        public int Phim_ID { get; set; }
        public string Noi_dung { get; set; }

        [ForeignKey("ThanhVien_ID")]
        public virtual ThanhVienModel idThanhVien { get; set; }
        [ForeignKey("Phim_ID")]
        public virtual PhimModel idPhim { get; set; }
    }
}
