using MakaleApp.Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MakaleApp.Data.Entity
{
    public class Makale : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MakaleId { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }

        [ForeignKey("Kategori")]
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }

        public virtual ICollection<Yorum> Yorums { get; set; }
    }
}
