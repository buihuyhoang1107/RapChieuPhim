using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class HoaDonModel
    {
        [Key]
        public int ID { get; set; }
        public  string Tong_tien { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Ngay_lap { get; set; }  
        public bool Da_xoa { get; set; }
        public int ThanhVien_ID { get; set; }

        [ForeignKey("ThanhVien_ID")]
        public virtual ThanhVienModel idThanhVien { get; set; }

        public ICollection<VeXemPhimModel> lstVeXemPhim { get; set; }
    }
}
