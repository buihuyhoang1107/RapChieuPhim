using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class NguoiDungModel
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Họ và tên")]
        public string HoTen { get; set; } //HoTe -> HoTen
        [DisplayName("Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập Email!")]
        [StringLength(maximumLength: 50, MinimumLength = 10, ErrorMessage = "Email phải từ 10-50 ký tự!")]
        public string Email { get; set; }
        [DisplayName("Địa chỉ")]

        public string Dia_chi { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Ngày sinh")]
        public DateTime Ngay_sinh { get; set; }
        [DisplayName("Số điện thoại")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập SĐT!")]
        [StringLength(maximumLength: 11, MinimumLength = 10, ErrorMessage = "SĐT phải từ 10-11 ký tự!")]
        public string Sdt { get; set; }
        [DisplayName("Admin")]
        public bool Admin { get; set; }
        [DisplayName("Đã xóa")]
        public bool Da_xoa { get; set; }

        public ICollection<HoaDonModel> lstHoaDon { get; set; }
        public ICollection<BinhLuanModel> lstBinhLuan { get; set; }
        public ICollection<TaiKhoanModel> lstTaiKhoan { get; set; }

    }
}
