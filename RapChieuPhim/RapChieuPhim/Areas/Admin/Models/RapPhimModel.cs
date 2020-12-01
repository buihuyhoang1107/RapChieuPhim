using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class RapPhimModel
    {
        [Key]
        public int ID { get; set; }
        public string Ten_rap { get; set; }
        public string Dia_chi { get; set; }
        public bool Da_xoa { get; set; }

        public ICollection<LichChieuModel> lstLichChieu { get; set; }
        public ICollection<PhongChieuModel> lstPhongChieu { get; set; }
        public ICollection<VeXemPhimModel> lstVeXemPhim { get; set; }
    }
}
