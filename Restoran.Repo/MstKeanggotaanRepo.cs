using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran.Model;
using Restoran.ViewModel;
using System.Data.Entity;

namespace Restoran.Repo
{
    public class MstKeanggotaanRepo
    {
        public List<MstKeanggotaanViewModel> GetAll()
        {

            List<MstKeanggotaanViewModel> result = new List<MstKeanggotaanViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstKeanggotaan
                          select new ViewModel.MstKeanggotaanViewModel
                          {
                              ID = mstk.ID,
                              KodeKeanggotaan = mstk.KodeKeanggotaan,
                              KodeTipeKeanggotaan = mstk.KodeTipeKeanggotaan,
                              NomerIdentitas = mstk.NomerIdentitas,
                              NamaLengkap = mstk.NamaLengkap,
                              Alamat = mstk.Alamat,
                              NomerHandphone=mstk.NomerHandphone,
                              Email = mstk.Email,
                          }
                ).ToList();
            }
            return result;
        }
        public List<MstKeanggotaanViewModel> GetSearch(string key)
        {
            List<MstKeanggotaanViewModel> result = new List<MstKeanggotaanViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstKeanggotaan
                          where mstk.NamaLengkap.ToLower().Contains(key.ToLower())
                          select new MstKeanggotaanViewModel
                          {
                              ID = mstk.ID,
                              KodeKeanggotaan = mstk.KodeKeanggotaan,
                              KodeTipeKeanggotaan = mstk.KodeTipeKeanggotaan,
                              NomerIdentitas = mstk.NomerIdentitas,
                              NamaLengkap = mstk.NamaLengkap,
                              Alamat = mstk.Alamat,
                              NomerHandphone = mstk.NomerHandphone,
                              Email = mstk.Email,
                          }
                ).ToList();
            }
            return result;
        }

        public bool cekdatakodekeanggotaan (string kodekeanggotaan)
        {
            bool cek = false;
            List<MstKeanggotaanViewModel> result = new List<MstKeanggotaanViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstKeanggotaan
                          where mstk.KodeKeanggotaan.ToLower().Contains(kodekeanggotaan.ToLower())
                          select new ViewModel.MstKeanggotaanViewModel
                          {
                              ID = mstk.ID,
                              KodeKeanggotaan = mstk.KodeKeanggotaan,
                              KodeTipeKeanggotaan = mstk.KodeTipeKeanggotaan,
                              NomerIdentitas = mstk.NomerIdentitas,
                              NamaLengkap = mstk.NamaLengkap,
                              Alamat = mstk.Alamat,
                              NomerHandphone = mstk.NomerHandphone,
                              Email = mstk.Email,
                          }
                ).ToList();
            }
            if (result.Count() > 0)
            {
                cek = true;
            }
            return cek;
        }

        public bool Save(MstKeanggotaanViewModel model)
        {
            bool result = true;

            using (DataContext context = new DataContext())
            {
                MstKeanggotaan mdlKeanggotaan = new MstKeanggotaan();
                              mdlKeanggotaan.ID = model.ID;
                              mdlKeanggotaan.KodeKeanggotaan = model.KodeKeanggotaan;
                              mdlKeanggotaan.KodeTipeKeanggotaan = model.KodeTipeKeanggotaan;
                              mdlKeanggotaan.NomerIdentitas = model.NomerIdentitas;
                              mdlKeanggotaan.NamaLengkap = model.NamaLengkap;
                              mdlKeanggotaan.Alamat = model.Alamat;
                              mdlKeanggotaan.NomerHandphone=model.NomerHandphone;
                              mdlKeanggotaan.Email =model.Email;

               context.mstKeanggotaan.Add(mdlKeanggotaan);
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
        public bool Remove
           (int id)
        {
            using (DataContext context = new DataContext())
            {
                MstKeanggotaan mdlKeanggotaan = context.mstKeanggotaan.Where(model => model.ID == id).FirstOrDefault();
                context.mstKeanggotaan.Remove(mdlKeanggotaan);
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
        public MstKeanggotaan GetByID(int id)
        {
            var vKeanggotaan = new MstKeanggotaan();
            vKeanggotaan = context.mstKeanggotaan.Where(x => x.ID == id).FirstOrDefault();
            return vKeanggotaan;

        }

        public bool Edit(MstKeanggotaan model)
        {
            bool result = true;

            MstKeanggotaan mdlKeanggotaan = new MstKeanggotaan();
            mdlKeanggotaan = context.mstKeanggotaan.Where(x => x.ID == model.ID).FirstOrDefault();
            mdlKeanggotaan.KodeKeanggotaan = model.KodeKeanggotaan;
            mdlKeanggotaan.KodeTipeKeanggotaan = model.KodeTipeKeanggotaan;
            mdlKeanggotaan.NomerIdentitas = model.NomerIdentitas;
            mdlKeanggotaan.NamaLengkap = model.NamaLengkap;
            mdlKeanggotaan.Alamat = model.Alamat;
            mdlKeanggotaan.NomerHandphone = model.NomerHandphone;
            mdlKeanggotaan.Email = model.Email;

            context.Entry(mdlKeanggotaan).State = EntityState.Modified;
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
