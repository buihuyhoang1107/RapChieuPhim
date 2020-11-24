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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int idPhim { get; set; }
        public string tenPhim { get; set; }
        public string ngayDang { get; set; }
        public int binhluanPhim { get; set; }
        public string motaPhim { get; set; }
        public string anhPhim { get; set; }
        public int trangThaiPhim { get; set; }
        public int idP_ChuDe { get; set; }
        [ForeignKey("idP_ChuDe")]
        public virtual ChuDePhimModel idChuDe { get; set; }
    }
}
