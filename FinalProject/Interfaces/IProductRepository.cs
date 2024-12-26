using FinalProject.Models;
using System.Threading.Tasks;


namespace FinalProject.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<Product> GetMostStockedProductAsync(); // Yeni metod

        Task<Product> GetMostOrderedProductAsync();
        Task<List<Product>> GetProductsOver500TLAsync();
        Task<int> GetTotalStockAsync();

    }
}
