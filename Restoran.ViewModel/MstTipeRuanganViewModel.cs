using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran.ViewModel
{
    public class MstTipeRuanganViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KodeTipeRuangan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string JenisRuangan { get; set; }

        public Double BiayaRuangan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Status { get; set; }
    }
}
