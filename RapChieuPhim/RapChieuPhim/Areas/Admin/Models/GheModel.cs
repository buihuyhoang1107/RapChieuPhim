using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class GheModel
    {
        [Key]
        public int ID { get; set; }
        public string Ten { get; set; }
        public int Loai { get; set; }
        public bool Da_chon { get; set; }
        public bool Da_xoa { get; set; }
        public int PhongChieu_ID { get; set; }

        [ForeignKey("PhongChieu_ID")]
        public virtual PhongChieuModel idPhongChieu { get; set; }

        public ICollection<VeXemPhimModel> lstVeXemPhim { get; set; }

    }
}
