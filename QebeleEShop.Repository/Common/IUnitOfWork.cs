using QebeleEShop.Repository.Infrastructure;

namespace QebeleEShop.Repository.Common;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }
    IUserRepository UserRepository { get; }

    IProductRepository ProductRepository { get; }
    //IOrderRepository OrderRepository { get; }
    //ICustomerRepository CustomerRepository { get; }
    //IOrderItemRepository OrderItemRepository { get; }
    Task Save();
}
