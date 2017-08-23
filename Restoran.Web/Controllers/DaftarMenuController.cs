using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Repo;
using Restoran.ViewModel;
using Restoran.Model;

namespace Restoran.Web.Controllers
{
    public class DaftarMenuController : Controller
    {
        MstDaftarMenuRepo serviceDaftarMenu = new MstDaftarMenuRepo();
        MstKategoriMenuRepo serviceKategoriMenu = new MstKategoriMenuRepo();
        //
        // GET: /Kategori/
        public ActionResult Index()
        {
            //ambil data
            return View();
        }

        public ActionResult GetList()
        {
            List<MstDaftarMenuViewModel> mstdaftarmenunviewmodel = serviceDaftarMenu.GetAll();
            return PartialView("_ListDaftarMenu", mstdaftarmenunviewmodel);
        }
        public ActionResult Create()
        {
            ViewBag.ListKategoriMenu = new SelectList(serviceKategoriMenu.GetAll(), "KodeKategoriMenu", "NamaKategoriMenu");
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstDaftarMenuViewModel model)
        {
            //DataSet dsID = Common.ExecuteDataSet("spoMaxIdPegawai");
            //int intID = dsID.Tables[0].Rows[0].Field<int>("MaksimumID");
            //model.ID = intID + 1;
            if (ModelState.IsValid)
            {
                if (serviceDaftarMenu.Save(model))
                {
                    return Json(new { Pesan = "Success" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Pesan = "Gagal" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            if (id >= 0)
            {
                if (serviceDaftarMenu.Remove(id))
                {
                    return Json(new { Pesan = "Success" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Pesan = "Gagal" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }

        public ActionResult Search(string key)
        {
            List<MstDaftarMenuViewModel> mstdaftarmenunviewmodel = serviceDaftarMenu.GetSearch(key);
            return PartialView("_ListDaftarMenu", mstdaftarmenunviewmodel);
        }

        public ActionResult Edit(int id)
        {
            var vDaftarMenu = serviceDaftarMenu.GetByID(id);
            ViewBag.ListKategoriMenu = new SelectList(serviceKategoriMenu.GetAll(), "KodeKategoriMenu", "NamaKategoriMenu");
            return PartialView("_Edit", vDaftarMenu);
        }

        [HttpPost]
        public ActionResult Edit(MstDaftarMenu model)
        {

            if (ModelState.IsValid)
            {
                if (serviceDaftarMenu.Edit(model))
                {
                    return Json(new { Pesan = "Success" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Pesan = "Gagal" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }
	}
}