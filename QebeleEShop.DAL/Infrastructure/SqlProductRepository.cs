using Microsoft.EntityFrameworkCore;
using QebeleEShop.DAL.Context;
using QebeleEShop.Domain.Entities;
using QebeleEShop.Repository.Infrastructure;

namespace QebeleEShop.DAL.Infrastructure;


public class SqlProductRepository : BaseSqlRepository, IProductRepository
{
    private readonly ShopDbContext _context;
    public SqlProductRepository(string connectionString, ShopDbContext context) : base(connectionString)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        await _context.AddAsync(product);
    }

    public async void Delete(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
        if (product != null)
        {
            product.IsDeleted = true;
            product.DeletedDate = DateTime.UtcNow;
        }
    }

    public IQueryable<Product> GetAll()
    {
        return _context.Products.Where(c => !c.IsDeleted);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
    }

    public void UpdateAsync(Product product)
    {
        product.UpdatedDate = DateTime.UtcNow;
        _context.Products.Update(product);
    }
}

