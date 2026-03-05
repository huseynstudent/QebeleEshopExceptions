using QebeleEShop.DAL.Context;
using QebeleEShop.Domain.Entities;
using QebeleEShop.Repository.Infrastructure;

namespace QebeleEShop.DAL.Infrastructure;

public class SqlUserRepository : BaseSqlRepository, IUserRepository
{
    private readonly ShopDbContext _context;

    public SqlUserRepository(string connectionString,ShopDbContext shopDbContext) : base(connectionString)
    {
        _context = shopDbContext;
    }

    public void DeleteAsync(int id)
    {
        var currentUser = _context.Users.FirstOrDefault(x => x.Id == id);
        if (currentUser != null)
        {
            currentUser.IsDeleted = true;
            _context.SaveChanges();
        }
    }

    public IQueryable<User> GetAllAsync()
    {
        return _context.Users.Where(x => !x.IsDeleted);
    }

    public Task<User> GetByEmailAsync(string email)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == email && !x.IsDeleted);
        return Task.FromResult(user);
    }


    public Task<User> GetByIdAsync(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        return Task.FromResult(user);
    }

    public Task RegisterAsync(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        user.CreatedDate = DateTime.UtcNow;
        return Task.CompletedTask;

    }

    public void UpdateAsync(User user)
    {
        var currentUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);
        if (currentUser != null)
        {
            currentUser.Name = user.Name;
            currentUser.Surname = user.Surname;
            currentUser.Email = user.Email;
            currentUser.PasswordHash = user.PasswordHash;
            currentUser.UpdatedDate = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
