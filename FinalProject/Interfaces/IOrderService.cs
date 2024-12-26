using FinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;

namespace FinalProject.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task<decimal> GetTotalOrderAmountAsync(); // Toplam sipariş miktarını hesaplama
        Task<List<Order>> GetOrdersAfterDateAsync(DateTime date);
    }
}
