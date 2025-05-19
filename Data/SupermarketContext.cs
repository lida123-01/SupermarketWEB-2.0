using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Models;

namespace SupermarketWEB.Data
{
    public class SupermarketContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorries { get; set; }
    }
}
