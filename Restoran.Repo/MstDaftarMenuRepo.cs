﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran.ViewModel;
using Restoran.Model;

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
                              status = mstk.Status,
                              
                          }
                ).ToList();
            }
            return result;
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
                              mdlMenuDaftar.Status = model.status;

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
                              status = mstk.Status,
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
    }
}
