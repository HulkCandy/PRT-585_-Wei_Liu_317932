using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data
{
    public class ProductAPIContext : DbContext
    {
        public ProductAPIContext (DbContextOptions<ProductAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProductAPI.Models.Product> Product { get; set; }
    }
}
