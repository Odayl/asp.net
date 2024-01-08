using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Models;

namespace ProjetFinal.Data
{
    public class FoodDBContext : DbContext
    {
        public FoodDBContext (DbContextOptions<FoodDBContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Food { get; set; } = default!;

        public DbSet<ProjetFinal.Models.Chef>? Chef { get; set; }
    }
}
