using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran.Model
{
    public class MstPengirimanDetail
    {
        public int ID { get; set; }
        public string KodeDaftarMenu { get; set; }
        public string KodePengiriman { get; set; }
        public int Banyak { get; set; }
        public Decimal TotalBiaya { get; set; }
    }
}
