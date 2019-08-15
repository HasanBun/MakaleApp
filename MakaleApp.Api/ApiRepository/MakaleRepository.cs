﻿using MakaleApp.Data.Context;
using MakaleApp.Data.Entity;
using MakaleApp.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakaleApp.Api.ApiRepository
{
    public class MakaleRepository : BaseRepository<Makale>
    {
        public MakaleRepository(MakaleDbContext context) : base(context)
        {
            
        }
    }
}
