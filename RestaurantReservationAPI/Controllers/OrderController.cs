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
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Gets a list of all orders.
        /// </summary>
        /// <returns>A list of orders.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }

        /// <summary>
        /// Gets an order by id.
        /// </summary>
        /// <param name="id">The id of the order to get.</param>
        /// <response code="200">Returns the requested order.</response>
        /// <response code="404">If the order is not found.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <returns>An order.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrderDto>(order));
        }

        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="orderDto">The order data transfer object.</param>
        /// <returns>The created order.</returns>
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(CreateOrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);

            await _orderRepository.AddAsync(order);

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        /// <summary>
        /// Updates an existing order.
        /// </summary>
        /// <param name="id">The id of the order to update.</param>
        /// <param name="orderDto">The order data transfer object.</param>
        /// <response code="204">If the update is successful.</response>
        /// <response code="404">If the order is not found.</response>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutOrder(int id, CreateOrderDto orderDto)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            _mapper.Map(orderDto, order);

            await _orderRepository.UpdateAsync(order);

            return NoContent();
        }

        /// <summary>
        /// Deletes an order by id.
        /// </summary>
        /// <param name="id">The id of the order to delete.</param>
        /// <response code="204">If the deletion is successful.</response>
        /// <response code="404">If the order is not found.</response>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            await _orderRepository.DeleteAsync(order);

            return NoContent();
        }
    }
}