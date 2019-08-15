using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MakaleApp.Data.Entity;

namespace MakaleApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MakaleApp.Data.Entity.Makale> Makale { get; set; }
        public DbSet<MakaleApp.Data.Entity.Yorum> Yorum { get; set; }
    }
}
