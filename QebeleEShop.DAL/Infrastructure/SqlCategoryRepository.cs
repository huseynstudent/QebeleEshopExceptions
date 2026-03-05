using Microsoft.EntityFrameworkCore;
using QebeleEShop.DAL.Context;
using QebeleEShop.Domain.Entities;
using QebeleEShop.Repository.Infrastructure;
using System.Threading.Tasks;

namespace QebeleEShop.DAL.Infrastructure;

public class SqlCategoryRepository : BaseSqlRepository, ICategoryRepository
{
    private readonly ShopDbContext _context;
    public SqlCategoryRepository(string connectionString,ShopDbContext context) : base(connectionString)
    {
        _context = context;
    }

    public async Task AddAsync(Category category)
    {
        await _context.AddAsync(category);
    }

    public async void Delete(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category != null)
        {
            category.IsDeleted = true;
            category.DeletedDate = DateTime.UtcNow;
        }
    }

    public IQueryable<Category> GetAll()
    {
        return _context.Categories.Where(c => !c.IsDeleted);
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
    }

    public void UpdateAsync(Category category)
    {
        category.UpdatedDate = DateTime.UtcNow;
        _context.Categories.Update(category);
    }
}
