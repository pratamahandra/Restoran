using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Restoran.Model
{
    public class MstPesananDetail
    {
        public int ID { get; set; }
        public string KodePesanan { get; set; }
        public string KodeDaftarMenu { get; set; }
        public string JumlahPesanan { get; set; }
        public string TotalBiaya { get; set; }
    }
}
