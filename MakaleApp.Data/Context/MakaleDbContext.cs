using JetBrains.Annotations;
using MakaleApp.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakaleApp.Data.Context
{
    public class MakaleDbContext : DbContext
    {
        public MakaleDbContext(DbContextOptions<MakaleDbContext> options) : base(options)
        {
        }

        public DbSet<Makale> Makale { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
    }
}
