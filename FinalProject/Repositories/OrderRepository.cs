using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Interfaces;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(o => o.Customer).Include(o => o.Product).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.Include(o => o.Customer).Include(o => o.Product).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetTotalOrderAmountAsync()
        {
            return await _context.Orders
                .Include(o => o.Product)
                .SumAsync(o => o.Quantity * o.Product.Price);
        }
        public async Task<List<Order>> GetOrdersAfterDateAsync(DateTime date)
        {
            return await _context.Orders
                .Where(o => o.OrderDate > date)
                .ToListAsync();
        }
    }
}
