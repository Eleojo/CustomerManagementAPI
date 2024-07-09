using Core;
using Data.Dto;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost("AddCustomer")]
        public async Task<ActionResult<string>> AddCustomer(CustomerDto customerDto)
        {
            try
            {
               await  _customerService.SignUpCustomerAsync(customerDto);
                return Ok("Sign up was successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }


        [HttpGet("GetCustomerDetail/{customerId}")]
        public async Task<ActionResult<Customer>> CustomerDetail(Guid customerId)
        {
            try
            {
                var customer = await _customerService.CustomerDetails(customerId);
                if (customer == null) { return NotFound(); }
                return Ok(customer);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("HardDelete/{customerId}")]
        public async Task<ActionResult> DeleteCustomer(Guid customerId)
        {
            try
            {
                var customerDeleted = await _customerService.HardDeleteCustomerAsync(customerId);
                if (!customerDeleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete("Soft-Delete/{customerId}")]
        public async Task<IActionResult> SoftDeleteCustomer(Guid customerId)
        {
            var result = await _customerService.SoftDeleteCustomerAsync(customerId);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpPut("Update-Customer/{customerId}-{name}-{email}-{password}")]
        public async Task<ActionResult> UpdateCustomerDetails(Guid customerId, string name, string email, string password)
        {
            try
            {
                var customer = await _customerService.UpdateCustomerAsync(customerId,name,email,password);
                if(customer == null)
                {
                    return NotFound();
                }
                return Ok("Successfully Updated Customer Record");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }




    }
}
