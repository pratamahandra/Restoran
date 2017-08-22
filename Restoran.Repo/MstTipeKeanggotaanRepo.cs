using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran.Model;
using Restoran.ViewModel;


namespace Restoran.Repo
{
    public class MstTipeKeanggotaanRepo
    {
        public List<MstTipeKeanggotaanViewModel> GetAll()
        {
            List<MstTipeKeanggotaanViewModel> result = new List<MstTipeKeanggotaanViewModel>();
            using (DataContext context = new DataContext())
            {
                result = (from mstk in context.mstTipeKeanggotaan
                          select new ViewModel.MstTipeKeanggotaanViewModel
                          {
                              ID = mstk.ID,
                              KodeTipeKeanggotaan = mstk.KodeTipeKeanggotaan,
                              JenisKeanggotaan = mstk.JenisKeanggotaan,
                              Diskon=mstk.Diskon
                          }
                ).ToList();
            }
            return result;
        }
    }
}
