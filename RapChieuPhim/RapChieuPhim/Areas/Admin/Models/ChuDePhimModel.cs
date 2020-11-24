using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class ChuDePhimModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int idChuDe { get; set; }
        public string tenChuDe { get; set; }
        public int trangThaiChuDe { get; set; }
        public ICollection<PhimModel> lstPost { get; set; }
    }
}
