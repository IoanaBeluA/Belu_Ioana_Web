using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Belu_Ioana_Web.Models;

namespace Belu_Ioana_Web.Data
{
    public class Belu_Ioana_WebContext : DbContext
    {
        public Belu_Ioana_WebContext (DbContextOptions<Belu_Ioana_WebContext> options)
            : base(options)
        {
        }

        public DbSet<Belu_Ioana_Web.Models.Jurnal> Jurnal { get; set; } = default!;

        public DbSet<Belu_Ioana_Web.Models.CategorieAliment> CategorieAliment { get; set; }
        public DbSet<Belu_Ioana_Web.Models.Categorie> Categorie{ get; set; }
    }
}
