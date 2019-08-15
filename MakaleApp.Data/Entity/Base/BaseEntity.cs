using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MakaleApp.Data.Entity.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        public bool IsDeleted { get; set; } = false;

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        [MaxLength(128)]
        public string CreatedUserId { get; set; }

        [MaxLength(128)]
        public string UpdatedUserId { get; set; }
    }
}
