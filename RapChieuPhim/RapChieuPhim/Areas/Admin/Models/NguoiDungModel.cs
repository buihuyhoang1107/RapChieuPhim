using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class NguoiDungModel
    {
        [Key]
        public int ID { get; set; }
        public string HoTen { get; set; } //HoTe -> HoTen

        public string Email { get; set; }
        public string Dia_chi { get; set; }
        [DataType(DataType.Date)]
        public DateTime Ngay_sinh { get; set; }
        public string Sdt { get; set; }
        public bool Admin { get; set; }
        public bool Da_xoa { get; set; }

        public ICollection<HoaDonModel> lstHoaDon { get; set; }
        public ICollection<BinhLuanModel> lstBinhLuan { get; set; }
        public ICollection<TaiKhoanModel> lstTaiKhoan { get; set; }

    }
}
