using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran.ViewModel
{
    public class MstKeanggotaanViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KodeKeanggotaan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KodeTipeKeanggotaan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string NomerIdentitas { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string NamaLengkap { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Alamat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string NomerHandphone { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string Email { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string JenisKeanggotaan { get; set; }
    }
}
