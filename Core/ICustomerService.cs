using Data.Dto;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface ICustomerService
    {
        Task SignUpCustomerAsync(CustomerDto customerDto);
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> CustomerDetails(Guid customerId);
        Task<bool> HardDeleteCustomerAsync(Guid customerId);
        Task<Customer> SoftDeleteCustomerAsync(Guid customerId);
        Task<Customer> UpdateCustomerAsync(Guid customerId, string name, string email, string password);
    }
}
