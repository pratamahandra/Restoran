using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran.ViewModel
{
    public class MstKategoriMenuViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KodeKategoriMenu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string NamaKategoriMenu { get; set; }

    }
}
