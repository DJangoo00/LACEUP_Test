using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApiContext _context;

        public OrderRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .ToListAsync();
    }

    public override async Task<Order> GetByIdAsync(int id)
    {
        return await _context.Orders
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    }
}