using QebeleEShop.DAL.Context;
using QebeleEShop.DAL.Infrastructure;
using QebeleEShop.Repository.Common;
using QebeleEShop.Repository.Infrastructure;

namespace QebeleEShop.DAL.UnitOfWork;

public class SqlUnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;
    private readonly ShopDbContext _context;

    public SqlUnitOfWork(string connectionString, ShopDbContext context)
    {
        _connectionString = connectionString;
        _context = context;
    }

    public SqlCategoryRepository _categoryRepository;
    public SqlUserRepository _userRepository;
    public SqlProductRepository _productRepository;

    public ICategoryRepository CategoryRepository => _categoryRepository ??= new SqlCategoryRepository(_connectionString, _context);
    public IUserRepository UserRepository => _userRepository ??= new SqlUserRepository(_connectionString, _context);
    public IProductRepository ProductRepository => _productRepository ??= new SqlProductRepository(_connectionString, _context);

    public Task Save()
    {
        return _context.SaveChangesAsync();
    }
}
