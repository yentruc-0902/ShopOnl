using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan.Model;
using Page
using PagedList.Mvc;

namespace Doan.Areas.PrivatePage.Controllers
{
    public class SanPhamDKDController : Controller


    {
        ShopOnline_DemoEntities1 db = new ShopOnline_DemoEntities1();
        // GET: PrivatePage/SanPhamDKD
        private List<SanPham> Laysanphammoi(int count)
        {
            return data.SanPhams.OrderBy(a => a.MaSP).Take(count).ToList();
        }
        // GET: NNClothing
        public ActionResult SanPham(int? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            var sanphammoi = Laysanphammoi(36);
            return View(sanphammoi.ToPagedList(pageNum, pageSize));
        }

        // GET: NNClothing
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult LoaiSanPham()
        {
            var loaiSp = from LSP in data.LoaiSps select LSP;
            return PartialView(loaiSp);
        }
        public ActionResult SPTheoLSP(int id)
        {
            var sanpham = from sp in data.SanPhams where sp.MaLSP == id select sp;
            return View(sanpham);
        }
        public ActionResult ChiTiet(int id)
        {
            var SP = from sp in data.SanPhams where sp.MaSP == id select sp;
            return View(SP.Single());
        }


    }
}