using MakaleApp.Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MakaleApp.Data.Entity
{
    public class Kategori : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
    }
}
