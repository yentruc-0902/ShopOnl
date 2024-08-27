using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan.Model;


namespace Doan.Controllers
{
    public class TaikhoanController : Controller
    {
        ShopOnline_DemoEntities1 db = new ShopOnline_DemoEntities1();
        // GET: Taikhoan
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection col, TaiKhoan tk )
        {
            var tendn = col["TenDN"];
            var mk = col["Matkhau"];
            var e = col["Email"];
            var dc = col["DiaChi"];
            var sdt = col["SoDT"];
            if (string.IsNullOrEmpty(tendn))
            {
                ViewData["loi1"] = " Tên đăng nhập là thông tin bắt buộc  ";
            }
            if (string.IsNullOrEmpty(mk))
            {
                ViewData["loi2"] = " Mật khẩu là thông tin bắt buộc ";
            }
            if (string.IsNullOrEmpty(e))
            {
                ViewData["loi3"] = " Email là thông tin bắt buộc ";
            }
            if (string.IsNullOrEmpty(dc))
            {
                ViewData["loi4"] = " Địa chỉ là thông tin bắt buộc ";
            }
            if (string.IsNullOrEmpty(sdt))
            {
                ViewData["loi5"] = " Số điện thoại là thông tin bắt buộc ";
            }
            else
            {
                tk.tenTV= tendn;
                tk.matKhau= mk;
                 tk.email = e;
                tk.diaChi= dc;
                tk.soDT= sdt;
              
                return RedirectToAction("Dangnhap");
            }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection col)
        {
            var tendn = col["TenDN"];
            var mk = col["Matkhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["loi1"] = " Tên đăng nhập là thông tin bắt buộc ";
            }
            else if (String.IsNullOrEmpty(mk))
            {
                ViewData["loi2"] = " Mặt khẩu là thông tin bắt buộc ";
            }
            else
            {
                TaiKhoan tk  = db.TaiKhoans.SingleOrDefault(n => n.tenTV == tendn && n.matKhau == mk);
                if (tk != null)
                {
                    //ViewBag.ThongBao = "Chào mừng đăng nhập thành công";
                    Session["TaiKhoan"] =tk;
                    return RedirectToAction("Giohang", "GioHang");

                }
                else ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng ";
            }
            return View();
        }


    }
}
