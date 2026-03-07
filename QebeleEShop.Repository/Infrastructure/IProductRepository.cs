using QebeleEShop.Domain.Entities;

namespace QebeleEShop.Repository.Infrastructure;

public interface IProductRepository
{
    Task AddAsync(Product product);
    void UpdateAsync(Product product);
    void Delete(int id);
    Task<Product> GetByIdAsync(int id);
    IQueryable<Product> GetAll();
}
