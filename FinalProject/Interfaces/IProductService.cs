using FinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FinalProject.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<Product> GetMostOrderedProductAsync();

        Task<int> GetTotalStockAsync();
        Task<List<Product>> GetProductsOver500TLAsync();
    }
}
