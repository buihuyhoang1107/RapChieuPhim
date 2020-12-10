using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RapChieuPhim.Areas.Admin.Models;

namespace RapChieuPhim.Controllers
{
    public class TaiKhoanController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = @"Data Source=THANHSON\SQLEXPRESS;Initial Catalog=db_RCP;Integrated Security=True";
        }
        [HttpPost]
        public IActionResult Verify(TaiKhoanModel tai_khoan)
        {
            try
            {
                connectionString();
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT * FROM TaiKhoanModel WHERE Ten_dang_nhap=@ten_dang_nhap and Mat_khau=@mat_khau";
                com.Parameters.AddWithValue("@ten_dang_nhap", tai_khoan.Ten_dang_nhap);
                com.Parameters.AddWithValue("@mat_khau", tai_khoan.Mat_khau);
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    return View("Success");
                }
                else
                {
                    con.Close();
                    return View("Error");
                }

            }
            catch (Exception err)
            {
                throw err;
            }
        }


    }
}
