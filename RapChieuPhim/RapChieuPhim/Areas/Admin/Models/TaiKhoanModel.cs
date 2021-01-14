using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Tên đăng nhập")]

        public string Ten_dang_nhap { get; set; }
        [DisplayName("Mật khẩu")]

        public string Mat_khau { get; set; }
        [DisplayName("Loại tài khoản")]

        public int Loai_tai_khoan { get; set; }// string -> int
        [DisplayName("Email")]

        public int NguoiDung_ID { get; set; }
        public bool Da_xoa { get; set; }

        [ForeignKey("NguoiDung_ID")]
        public virtual NguoiDungModel NguoiDungModel { get; set; }
    }
}
