using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan.Controllers  
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Acc, string Pass)
        {
            bool isAuthentic = (Acc != null && Pass != null && Acc.Equals("truclu0902@gmail.com") && Pass.Equals("090203"));
            if (isAuthentic)
                return RedirectToAction("Index", "Thongtinchung", new { Area = "PrivatePages" });
            // không thành công thì vẫn nhập lại được bth....
            else
                return View();
        }
    }
}