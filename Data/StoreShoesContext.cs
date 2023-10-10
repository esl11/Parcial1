using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using parcial1.Models;

namespace parcial1.Data
{
    public class StoreShoesContext : DbContext
    {
        public StoreShoesContext (DbContextOptions<StoreShoesContext> options)
            : base(options)
        {
        }

        public DbSet<parcial1.Models.Footwear> Footwear { get; set; } = default!;

        public DbSet<parcial1.Models.Store> Store { get; set; } = default!;
    }
}
