using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran.Model;
using Restoran.ViewModel;

namespace Restoran.Repo
{
    public class MstMejaRepo
    {
        public List<MstMejaViewModel> GetAll()
        {
            List<MstMejaViewModel> result = new List<MstMejaViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstMeja
                          select new ViewModel.MstMejaViewModel
                          {
                              ID = mstk.ID,
                              KodeMeja = mstk.KodeMeja,
                              KodeTipeRuangan = mstk.KodeTipeRuangan,
                              NomerMeja = mstk.NomerMeja,
                              Status = mstk.Status
                          }
                ).ToList();
            }
            return result;
        }

        public List<MstMejaViewModel> GetSearch(string key)
        {
            List<MstMejaViewModel> result = new List<MstMejaViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstMeja
                          where mstk.KodeMeja.ToLower().Contains(key.ToLower())
                          select new MstMejaViewModel
                          {
                              ID = mstk.ID,
                              KodeMeja = mstk.KodeMeja,
                              KodeTipeRuangan = mstk.KodeTipeRuangan,
                              NomerMeja = mstk.NomerMeja,
                              Status = mstk.Status
                          }
                ).ToList();
            }
            return result;
        }

        public bool Save(MstMejaViewModel model)
        {
            bool result = true;

            using (DataContext context = new DataContext())
            {
                MstMeja mdlMeja= new MstMeja();
                mdlMeja.ID = model.ID;
                mdlMeja.KodeMeja = model.KodeMeja;
                mdlMeja.KodeTipeRuangan = model.KodeTipeRuangan;
                mdlMeja.NomerMeja = model.NomerMeja;
                mdlMeja.Status = model.Status;

                context.mstMeja.Add(mdlMeja);
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
                MstMeja mdlMeja = context.mstMeja.Where(model => model.ID == id).FirstOrDefault();
                context.mstMeja.Remove(mdlMeja);
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
