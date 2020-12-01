﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.Admin.Models
{
    public class LichChieuModel
    {
        [Key]
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Ngay { get; set; }
        public bool Da_xoa { get; set; }
        public int RapPhim_ID { get; set; }

        [ForeignKey("RapPhim_ID")]
        public virtual RapPhimModel idRapPhim { get; set; }

        public ICollection<XuatChieuModel> lstXuatChieu { get; set; }
    }
}
