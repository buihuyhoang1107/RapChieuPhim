using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class ThanhVienModel:NguoiDungModel
    {
        public ICollection<HoaDonModel> lstHoaDon { get; set; }
        public ICollection<BinhLuanModel> lstBinhLuan { get; set; }

    }
}
