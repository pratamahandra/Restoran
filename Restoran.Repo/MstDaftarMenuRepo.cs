using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran.ViewModel;
using Restoran.Model;
using System.Data.Entity;

namespace Restoran.Repo
{
    public class MstDaftarMenuRepo
    {
        public List<MstDaftarMenuViewModel> GetAll()
        {
            List<MstDaftarMenuViewModel> result = new List<MstDaftarMenuViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstDaftarMenu
                          select new ViewModel.MstDaftarMenuViewModel
                          {
                              ID = mstk.ID,
                              KodeDaftarMenu = mstk.KodeDaftarMenu,
                              KodeKategoriMenu = mstk.KodeKategoriMenu,
                              NamaMenu = mstk.NamaMenu,
                              Harga = mstk.Harga,
                              Status = mstk.Status,
                              
                          }
                ).ToList();
            }
            return result;
        }

        public bool CekKode(MstDaftarMenuViewModel model)
        {
            bool cek = false;
            List<MstDaftarMenuViewModel> result = new List<MstDaftarMenuViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstDaftarMenu
                          where mstk.KodeDaftarMenu.ToLower().Contains(model.KodeDaftarMenu.ToLower())
                          select new MstDaftarMenuViewModel
                          {
                              ID = mstk.ID,
                              KodeDaftarMenu = mstk.KodeDaftarMenu,
                              KodeKategoriMenu = mstk.KodeKategoriMenu,
                              NamaMenu = mstk.NamaMenu,
                              Harga = mstk.Harga,
                              Status = mstk.Status,
                          }
                ).ToList();
            }
            if (result.Count() > 0)
            {
                cek = true;
            }
            return cek;
        }

        public bool Save(MstDaftarMenuViewModel model)
        {
            bool result = true;

            using (DataContext context = new DataContext())
            {
                MstDaftarMenu mdlMenuDaftar = new MstDaftarMenu();
                              mdlMenuDaftar.ID = model.ID;
                              mdlMenuDaftar.KodeDaftarMenu = model.KodeDaftarMenu;
                              mdlMenuDaftar.KodeKategoriMenu = model.KodeKategoriMenu;
                              mdlMenuDaftar.NamaMenu = model.NamaMenu;
                              mdlMenuDaftar.Harga = model.Harga;
                              mdlMenuDaftar.Status = model.Status;

               context.mstDaftarMenu.Add(mdlMenuDaftar);
                try
                {
                    context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    result = false;
                    return result;
                }

            }
        }

        public List<MstDaftarMenuViewModel> GetSearch(string key)
        {
            List<MstDaftarMenuViewModel> result = new List<MstDaftarMenuViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstDaftarMenu
                          where mstk.NamaMenu.ToLower().Contains(key.ToLower())
                          select new MstDaftarMenuViewModel
                          {
                              ID = mstk.ID,
                              KodeDaftarMenu = mstk.KodeDaftarMenu,
                              KodeKategoriMenu = mstk.KodeKategoriMenu,
                              NamaMenu = mstk.NamaMenu,
                              Harga = mstk.Harga,
                              Status = mstk.Status,
                          }
                ).ToList();
            }
            return result;
        }

        public bool Remove
           (int id)
        {
            using (DataContext context = new DataContext())
            {
                MstDaftarMenu mdlMenuDaftar = context.mstDaftarMenu.Where(model => model.ID == id).FirstOrDefault();
                context.mstDaftarMenu.Remove(mdlMenuDaftar);
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        DataContext context = new DataContext();

        public MstDaftarMenu GetByID(int id)
        {
            var vDaftarMenu = new MstDaftarMenu();
            vDaftarMenu = context.mstDaftarMenu.Where(x => x.ID == id).FirstOrDefault();
            return vDaftarMenu;

        }

        public bool Edit(MstDaftarMenu model)
        {
            bool result = true;

            MstDaftarMenu mdlMenuDaftar = new MstDaftarMenu();
            mdlMenuDaftar = context.mstDaftarMenu.Where(x => x.ID == model.ID).FirstOrDefault();
            mdlMenuDaftar.ID = model.ID;
            mdlMenuDaftar.KodeDaftarMenu = model.KodeDaftarMenu;
            mdlMenuDaftar.KodeKategoriMenu = model.KodeKategoriMenu;
            mdlMenuDaftar.NamaMenu = model.NamaMenu;
            mdlMenuDaftar.Harga = model.Harga;
            mdlMenuDaftar.Status = model.Status;

            context.Entry(mdlMenuDaftar).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                result = false;
                return result;
            }

        }
    }
}
