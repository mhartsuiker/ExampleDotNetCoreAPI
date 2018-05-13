using Microsoft.EntityFrameworkCore;
using Product.Contracts.DataTypes;

namespace Product.DataAccess
{
    public class ProductDataContext : DbContext
    {
        public ProductDataContext(DbContextOptions<ProductDataContext> options): base(options) {}

        public DbSet<Item> Item { get; set; }
        public DbSet<ItemDescription> ItemDescription { get; set; }
        public DbSet<ItemPrice> ItemPrice { get; set; }
    }
}