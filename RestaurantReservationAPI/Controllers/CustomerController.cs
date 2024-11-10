using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservationAPI.DTOs;
using RestaurantReservationAPI.Models;
using RestaurantReservationAPI.Repositories;

namespace RestaurantReservationAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Gets a list of all customers.
        /// </summary>
        /// <returns>A list of customers.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        /// <summary>
        /// Gets a customer by id.
        /// </summary>
        /// <param name="id">The id of the customer to get.</param>
        /// <response code="200">Returns the requested customer.</response>
        /// <response code="404">If the customer is not found.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <returns>A customer.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customerDto">The customer data transfer object.</param>
        /// <returns>The created customer.</returns>
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CreateCustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            await _customerRepository.AddAsync(customer);

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="id">The id of the customer to update.</param>
        /// <param name="customerDto">The customer data transfer object.</param>
        /// <response code="204">If the update is successful.</response>
        /// <response code="404">If the customer is not found.</response>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutCustomer(int id, CreateCustomerDto customerDto)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _mapper.Map(customerDto, customer);

            await _customerRepository.UpdateAsync(customer);

            return NoContent();
        }

        /// <summary>
        /// Deletes a customer by id.
        /// </summary>
        /// <param name="id">The id of the customer to delete.</param>
        /// <response code="204">If the deletion is successful.</response>
        /// <response code="404">If the customer is not found.</response>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            await _customerRepository.DeleteAsync(customer);

            return NoContent();
        }
    }
}