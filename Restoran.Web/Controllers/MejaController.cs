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
    public class MejaController : Controller
    {
        MstMejaRepo serviceMeja = new MstMejaRepo();
        MstTipeRuanganRepo serviceTipeRuangan = new MstTipeRuanganRepo();

        //
        // GET: /Kategori/
        public ActionResult Index()
        {
            //ambil data
            return View();
        }

        public ActionResult GetList()
        {
            List<MstMejaViewModel> mstmejaviewmodel = serviceMeja.GetAll();
            return PartialView("_ListMeja", mstmejaviewmodel);
        }

        public ActionResult Create()
        {
            ViewBag.ListTipeRuangan = new SelectList(serviceTipeRuangan.GetAll(), "KodeTipeRuangan", "JenisRuangan");
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstMejaViewModel model)
        {
            //DataSet dsID = Common.ExecuteDataSet("spoMaxIdPegawai");
            //int intID = dsID.Tables[0].Rows[0].Field<int>("MaksimumID");
            //model.ID = intID + 1;
            if (ModelState.IsValid)
            {
                if (serviceMeja.Save(model))
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
                if (serviceMeja.Remove(id))
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
            List<MstMejaViewModel> mstmejaviewmodel = serviceMeja.GetSearch(key);
            return PartialView("_ListMeja", mstmejaviewmodel);
        }
        public ActionResult Edit(int id)
        {
            var vMeja = serviceMeja.GetByID(id);
            return PartialView("_Edit", vMeja);
        }

        [HttpPost]
        public ActionResult Edit(MstMeja model)
        {

            if (ModelState.IsValid)
            {
                if (serviceMeja.Edit(model))
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