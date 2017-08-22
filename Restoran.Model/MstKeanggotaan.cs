using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran.Model
{
    public class MstKeanggotaan
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
        [StringLength(50)]
        public string NomerIdentitas { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string NamaLengkap { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Alamat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string NomerHandphone { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Email { get; set; }
       

    }
}
