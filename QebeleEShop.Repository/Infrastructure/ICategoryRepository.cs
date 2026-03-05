using QebeleEShop.Domain.Entities;

namespace QebeleEShop.Repository.Infrastructure;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    void UpdateAsync(Category category);
    void Delete(int id);
    Task<Category> GetByIdAsync(int id);
    IQueryable<Category> GetAll();
}
