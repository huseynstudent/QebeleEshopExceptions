using Microsoft.EntityFrameworkCore;
using QebeleEShop.Domain.Entities;

namespace QebeleEShop.DAL.Context;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
}
