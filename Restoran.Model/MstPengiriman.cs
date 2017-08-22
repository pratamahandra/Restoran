using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran.Model
{
    public class MstPengiriman
    {
        public int ID { get; set; }
        public string Kodepengiriman { get; set; }
        public string NamaPemesan { get; set; }
        public string Alamat { get; set; }
        public string NomerHandphone { get; set; }
    }
}
