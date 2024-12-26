using FinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace FinalProject.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
    }
}
