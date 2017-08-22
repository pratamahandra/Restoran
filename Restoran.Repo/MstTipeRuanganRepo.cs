using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran.ViewModel;
using Restoran.Model;

namespace Restoran.Repo
{
    public class MstTipeRuanganRepo
    {
        public List<MstTipeRuanganViewModel> GetAll()
        {
            List<MstTipeRuanganViewModel> result = new List<MstTipeRuanganViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstTipeRuangan
                          select new ViewModel.MstTipeRuanganViewModel
                          {
                              ID = mstk.ID,
                              KodeTipeRuangan = mstk.KodeTipeRuangan,
                              JenisRuangan = mstk.JenisRuangan,
                              BiayaRuangan = mstk.BiayaRuangan,
                              Status = mstk.Status
                          }
                ).ToList();
            }
            return result;
        }
    }
}
