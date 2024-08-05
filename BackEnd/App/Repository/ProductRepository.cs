using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApiContext _context;

        public ProductRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .ToListAsync();
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddRangeAsync(IEnumerable<Product> products)
        {
            await _context.Set<Product>().AddRangeAsync(products);
        }

        public async Task<IEnumerable<Product>> GetByOrder(int idOrder)
        {
            var result = await
            (
                    from p in _context.Products
                    join o in _context.Orders on p.IdOrderFk equals o.Id
                    where p.IdOrderFk == idOrder
                    //orderby p.Id
                    select p
            )
            .Distinct()
            .ToListAsync();
            return result;
        }
    }
}