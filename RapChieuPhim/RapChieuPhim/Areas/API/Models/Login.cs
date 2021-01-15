using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RapChieuPhim.Areas.API.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Mời đăng nhập username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Mời đăng nhập password")]
        public string password { get; set; }
    }
}
