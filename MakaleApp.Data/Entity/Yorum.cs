using MakaleApp.Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MakaleApp.Data.Entity
{
    public class Yorum : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YorumId { get; set; }
        public string YorumIcerik { get; set; }

        [ForeignKey("Makale")]
        public int MakaleId { get; set; }
        public virtual Makale Makale { get; set; }
    }
}
