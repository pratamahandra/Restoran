using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran.Model
{
    public class MstPesanan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string KodePesanan { get; set; }
        public string KodeMeja { get; set; }
        public string WaktuPemesenanan { get; set; }
        public string Status { get; set; }
        

    }
}
