using System;
using System.Collections.Generic;
using System.Text;

namespace MakaleApp.Data.Entity.Base
{
    public interface IBaseEntity
    {
        bool IsDeleted { get; set; }

        DateTime CreateDate { get; set; }

        DateTime? UpdateDate { get; set; }

        string CreatedUserId { get; set; }

        string UpdatedUserId { get; set; }
    }
}
