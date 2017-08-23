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
    public class KeanggotaanController : Controller
    {
        MstKeanggotaanRepo serviceKeanggotaan = new MstKeanggotaanRepo();
        MstTipeKeanggotaanRepo serviceTipeKeanggotaan = new MstTipeKeanggotaanRepo();
        //
        // GET: /Kategori/
        public ActionResult Index()
        {
            //ambil data
            return View();
        }

        public ActionResult GetList()
        {
            List<MstKeanggotaanViewModel> mstkeanggotaanviewmodel = serviceKeanggotaan.GetAll();
            return PartialView("_ListKeanggotaan", mstkeanggotaanviewmodel);
        }
        public ActionResult Create()
        {
            ViewBag.ListTipeKeanggotaan = new SelectList(serviceTipeKeanggotaan.GetAll(), "KodeTipeKeanggotaan", "JenisKeanggotaan");
            return PartialView("_Create");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]

        public ActionResult Create(MstKeanggotaanViewModel model)
        {
            //DataSet dsID = Common.ExecuteDataSet("spoMaxIdPegawai");
            //int intID = dsID.Tables[0].Rows[0].Field<int>("MaksimumID");
            //model.ID = intID + 1;
            if (ModelState.IsValid)
            {
                if (serviceKeanggotaan.cekdatakodekeanggotaan(model.KodeKeanggotaan))
                {
                    return Json(new { Pesan = "Ada" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (serviceKeanggotaan.Save(model))
                    {
                        return Json(new { Pesan = "Success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { Pesan = "Gagal" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return View();
        }
        
        


        [HttpPost]
        public ActionResult Delete(int id)
        {

            if (id >= 0)
            {
                if (serviceKeanggotaan.Remove(id))
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
            List<MstKeanggotaanViewModel> mstkeanggotaanviewmodel = serviceKeanggotaan.GetSearch(key);                        
            return PartialView("_ListKeanggotaan", mstkeanggotaanviewmodel);
        }

        public ActionResult Edit(int id)
        {
            var vKeanggotaan = serviceKeanggotaan.GetByID(id);
            return PartialView("_Edit", vKeanggotaan);
        }

        [HttpPost]
        public ActionResult Edit(MstKeanggotaan model)
        {

            if (ModelState.IsValid)
            {
                if (serviceKeanggotaan.Edit(model))
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