using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran.Model;
using Restoran.ViewModel;

namespace Restoran.Repo
{
    public class MstPegawaiRepo
    {
        public List<MstPegawaiViewModel> GetAll()
        {
            List<MstPegawaiViewModel> result = new List<MstPegawaiViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstPegawai
                          select new ViewModel.MstPegawaiViewModel
                          {
                              ID = mstk.ID,
                              KodePegawai = mstk.KodePegawai,
                              NamaLengkap = mstk.NamaLengkap,
                              JenisKelamin = mstk.JenisKelamin,
                              Alamat = mstk.Alamat,
                              Email = mstk.Email,
                              Status = mstk.Status
                          }
                ).ToList();
            }
            return result;
        }

        public List<MstPegawaiViewModel> GetSearch(string key)
        {
            List<MstPegawaiViewModel> result = new List<MstPegawaiViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstPegawai
                          where mstk.NamaLengkap.ToLower().Contains(key.ToLower())
                          select new MstPegawaiViewModel
                          {
                              ID = mstk.ID,
                              KodePegawai = mstk.KodePegawai,
                              NamaLengkap = mstk.NamaLengkap,
                              JenisKelamin = mstk.JenisKelamin,
                              Alamat = mstk.Alamat,
                              Email = mstk.Email,
                              Status = mstk.Status
                          }
                ).ToList();
            }
            return result;
        }

        public bool Save(MstPegawaiViewModel model)
        {
            bool result = true;

            using (DataContext context = new DataContext())
            {
                MstPegawai mdlPegawai = new MstPegawai();
                mdlPegawai.ID = model.ID;
                mdlPegawai.KodePegawai = model.KodePegawai;
                mdlPegawai.NamaLengkap = model.NamaLengkap;
                mdlPegawai.JenisKelamin = model.JenisKelamin;
                mdlPegawai.Alamat = model.Alamat;
                mdlPegawai.Email = model.Email;
                mdlPegawai.Status = model.Status;

                context.mstPegawai.Add(mdlPegawai);
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
                MstPegawai mdlPegawai = context.mstPegawai.Where(model => model.ID == id).FirstOrDefault();
                context.mstPegawai.Remove(mdlPegawai);
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



