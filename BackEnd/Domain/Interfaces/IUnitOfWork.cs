using Domain.Entities;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IOrderRepository Orders { get; }
    IProductRepository Products { get; }
    //JWT
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }

    Task<int> SaveAsync();
}
