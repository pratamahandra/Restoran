using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran.ViewModel
{
    public class MstMejaViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KodeMeja { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string KodeTipeRuangan { get; set; }

        public int NomerMeja { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Status { get; set; }
    }
}
