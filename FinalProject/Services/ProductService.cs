using FinalProject.Interfaces;
using FinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Interfaces;
using FinalProject.Models;

namespace FinalProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
        public async Task<List<Product>> GetProductsOver500TLAsync()
        {
            return await _productRepository.GetProductsOver500TLAsync();
        }
        public async Task<Product> GetMostOrderedProductAsync()
        {
            return await _productRepository.GetMostOrderedProductAsync();
        }
        public async Task<int> GetTotalStockAsync()
        {
            return await _productRepository.GetTotalStockAsync();
        }


    }
}
