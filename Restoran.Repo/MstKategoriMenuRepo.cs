using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran.Model;
using Restoran.ViewModel;

namespace Restoran.Repo
{
   public class MstKategoriMenuRepo
    {
       public List<MstKategoriMenuViewModel> GetAll()
       {
           List<MstKategoriMenuViewModel> result = new List<MstKategoriMenuViewModel>();
           using (DataContext context = new DataContext())
           {
               result = (from mstk in context.mstKategoriMenu
                         select new ViewModel.MstKategoriMenuViewModel
                         {
                             ID = mstk.ID,
                             KodeKategoriMenu = mstk.KodeKategoriMenu,
                             NamaKategoriMenu = mstk.NamaKategoriMenu
                         }
               ).ToList();
           }
           return result;
       }
    }
}
