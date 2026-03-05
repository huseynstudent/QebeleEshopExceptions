using QebeleEShop.Domain.Entities;

namespace QebeleEShop.Repository.Infrastructure;

public interface IUserRepository
{
    Task RegisterAsync(User user);
    void UpdateAsync(User user);
    void DeleteAsync(int id);
    IQueryable<User> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> GetByEmailAsync(string email);
}
