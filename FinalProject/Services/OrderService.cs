using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace YourNamespace.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
        }

        public async Task<decimal> GetTotalOrderAmountAsync()
        {
            return await _orderRepository.GetTotalOrderAmountAsync();
        }
       
        public async Task<List<Order>> GetOrdersAfterDateAsync(DateTime date)
        {
            return await _orderRepository.GetOrdersAfterDateAsync(date);
        }

    }
}
