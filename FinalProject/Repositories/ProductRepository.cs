using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Interfaces;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Product>> GetProductsOver500TLAsync()
        {
            return await _context.Products
                .Where(p => p.Price > 500)
                .ToListAsync();
        }


        public async Task<Product> GetMostStockedProductAsync() // Eksik metod eklendi
        {
            return await _context.Products
                .OrderByDescending(p => p.Stock)
                .FirstOrDefaultAsync();
        }
        public async Task<Product> GetMostOrderedProductAsync()
        {
            var mostOrderedProduct = await _context.Orders
                .GroupBy(o => o.Product)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefaultAsync();
            return mostOrderedProduct;
        }
        public async Task<int> GetTotalStockAsync()
        {
            return await _context.Products.SumAsync(p => p.Stock);
        }


    }
}
