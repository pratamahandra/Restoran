using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Repo;
using Restoran.ViewModel;

namespace Restoran.Web.Controllers
{
    public class PegawaiController : Controller
    {
        MstPegawaiRepo serviceRestoran = new MstPegawaiRepo();
        public ActionResult Index()
        {
            //ambil data

            List<MstPegawaiViewModel> mstpegawaiviewmodel = serviceRestoran.GetAll();

            return View();
        }

        public ActionResult GetList()
        {
            List<MstPegawaiViewModel> mstpegawaiviewmodel = serviceRestoran.GetAll();
            return PartialView("_ListPegawai", mstpegawaiviewmodel);
        }

        public ActionResult Search(string key)
        {
            List<MstPegawaiViewModel> mstpegawaiviewmodel = serviceRestoran.GetSearch(key);
            return PartialView("_ListPegawai", mstpegawaiviewmodel);
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstPegawaiViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (serviceRestoran.ceknamapegawai(model.NamaLengkap))
                {
                    return Json(new { Pesan = "Ada" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (serviceRestoran.Save(model))
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
                if (serviceRestoran.Remove(id))
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
