using Data.AppDbContext;
using Data.Dto;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CustomerService : ICustomerService
    {
        private readonly Context _context;

        public CustomerService(Context context)
        {
            _context = context;
        }


        public async Task SignUpCustomerAsync(CustomerDto customerDto)
        {
            var newCustomer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Gender = customerDto.Gender,
                Password = customerDto.Password
            };
            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();  
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }


        public async Task<Customer> CustomerDetails(Guid customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);  
        }

        public async Task<bool> HardDeleteCustomerAsync(Guid customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);
            if (customer == null)
            {
                return false;
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Customer> SoftDeleteCustomerAsync(Guid customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);
            if (customer == null)
            {
                return null;
            }
            customer.IsDeleted = true;
            await _context.SaveChangesAsync();
            return customer;
        }


        public async Task<Customer> UpdateCustomerAsync(Guid customerId, string name, string email, string password)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                return null; // Customer not found
            }

            // Update customer properties
            customer.Name = name;
            customer.Email = email;
            customer.Password = password;
            // Add any other properties that need to be updated

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }


    }
}
