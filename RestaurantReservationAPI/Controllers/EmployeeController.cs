using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservationAPI.DTOs;
using RestaurantReservationAPI.Models;
using RestaurantReservationAPI.Repositories;

namespace RestaurantReservationAPI.Controllers
{
    [ApiController]
    [Route("api/employees")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Gets a list of all employees.
        /// </summary>
        /// <returns>A list of employees.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        /// <summary>
        /// Gets an employee by id.
        /// </summary>
        /// <param name="id">The id of the employee to get.</param>
        /// <response code="200">Returns the requested employee.</response>
        /// <response code="404">If the employee is not found.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <returns>An employee.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="employeeDto">The employee data transfer object.</param>
        /// <returns>The created employee.</returns>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);

            await _employeeRepository.AddAsync(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The id of the employee to update.</param>
        /// <param name="employeeDto">The employee data transfer object.</param>
        /// <response code="204">If the update is successful.</response>
        /// <response code="404">If the employee is not found.</response>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutEmployee(int id, CreateEmployeeDto employeeDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _mapper.Map(employeeDto, employee);

            await _employeeRepository.UpdateAsync(employee);

            return NoContent();
        }

        /// <summary>
        /// Deletes an employee by id.
        /// </summary>
        /// <param name="id">The id of the employee to delete.</param>
        /// <response code="204">If the deletion is successful.</response>
        /// <response code="404">If the employee is not found.</response>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            await _employeeRepository.DeleteAsync(employee);

            return NoContent();
        }

        /// <summary>
        /// Gets a list of all managers.
        /// </summary>
        /// <returns>A list of managers.</returns>
        [HttpGet("managers")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetManagers()
        {
            var managers = await _employeeRepository.GetManagersAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(managers));
        }

        /// <summary>
        /// Gets the average order amount for a specific employee.
        /// </summary>
        /// <param name="employeeId">The id of the employee.</param>
        /// <returns>The average order amount.</returns>
        [HttpGet("{employeeId}/average-order-amount")]
        public async Task<ActionResult<decimal>> GetAverageOrderAmount(int employeeId)
        {
            var averageOrderAmount = await _employeeRepository.GetAverageOrderAmountAsync(employeeId);
            return Ok(averageOrderAmount);
        }
    }
}