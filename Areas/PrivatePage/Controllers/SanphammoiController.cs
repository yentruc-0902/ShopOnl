using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Doan.Areas.PrivatePage.Controllers
{
    public class SanphammoiController : Controller
    {
       ShopOnline_DemoEntities data = new ShopOnline_DemoEntities();
        private List<SanPham> Laysanphammoi(int count)
        {
            return data.SanPhams.OrderBy(a => a.maSP).Take(count).ToList();
        }
        // GET: NNClothing
     
        // GET: NNClothing
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult LoaiSanPham()
        {
            var loaiSp = from LSP in data.LoaiSPs select LSP;
            return PartialView(loaiSp);
        }
        public ActionResult SPTheoLSP(int id)
        {
            var sanpham = from sp in data.SanPhams where sp.maLoai == id select sp;
            return View(sanpham);
        }
        public ActionResult ChiTiet( string id)
        {
            var SP = from sp in data.SanPhams where sp.maSP == id select sp;
            return View(SP.Single());
        }


    }
}