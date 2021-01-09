using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class TaiKhoanModel
    {
        [Key]
        public int ID { get; set; } // string -> int
        public string Ten_dang_nhap { get; set; }
        public string Mat_khau { get; set; }
        public int Loai_tai_khoan { get; set; }// string -> int
        public int NguoiDung_ID { get; set; }
        public bool Da_xoa { get; set; }

        [ForeignKey("NguoiDung_ID")]
        public virtual NguoiDungModel NguoiDungModel { get; set; }
    }
}
