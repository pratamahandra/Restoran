﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restoran.Model
{
   public class MstTipeKeanggotaan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KodeTipeKeanggotaan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string JenisKeanggotaan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Diskon { get; set; }
    }
}