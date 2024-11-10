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
    [Route("api/reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IMapper mapper, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        /// <summary>
        /// Gets a list of all reservations.
        /// </summary>
        /// <returns>A list of reservations.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservations()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ReservationDto>>(reservations));
        }

        /// <summary>
        /// Gets a reservation by id.
        /// </summary>
        /// <param name="id">The id of the reservation to get.</param>
        /// <response code="200">Returns the requested reservation.</response>
        /// <response code="404">If the reservation is not found.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <returns>A reservation.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReservationDto>> GetReservation(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReservationDto>(reservation));
        }

        /// <summary>
        /// Creates a new reservation.
        /// </summary>
        /// <param name="reservationDto">The reservation data transfer object.</param>
        /// <returns>The created reservation.</returns>
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(CreateReservationDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);

            await _reservationRepository.AddAsync(reservation);

            return CreatedAtAction(nameof(GetReservation), new { id = reservation.ReservationId }, reservation);
        }

        /// <summary>
        /// Updates an existing reservation.
        /// </summary>
        /// <param name="id">The id of the reservation to update.</param>
        /// <param name="reservationDto">The reservation data transfer object.</param>
        /// <response code="204">If the update is successful.</response>
        /// <response code="404">If the reservation is not found.</response>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutReservation(int id, CreateReservationDto reservationDto)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            _mapper.Map(reservationDto, reservation);

            await _reservationRepository.UpdateAsync(reservation);

            return NoContent();
        }

        /// <summary>
        /// Deletes a reservation by id.
        /// </summary>
        /// <param name="id">The id of the reservation to delete.</param>
        /// <response code="204">If the deletion is successful.</response>
        /// <response code="404">If the reservation is not found.</response>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            await _reservationRepository.DeleteAsync(reservation);

            return NoContent();
        }

        /// <summary>
        /// Gets reservations by customer id.
        /// </summary>
        /// <param name="customerId">The id of the customer.</param>
        /// <returns>A list of reservations for the specified customer.</returns>
        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservationsByCustomer(int customerId)
        {
            var reservations = await _reservationRepository.GetByCustomerIdAsync(customerId);

            if (reservations == null || !reservations.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ReservationDto>>(reservations));
        }

        /// <summary>
        /// Gets menu items by reservation id.
        /// </summary>
        /// <param name="reservationId">The id of the reservation.</param>
        /// <returns>A list of menu items for the specified reservation.</returns>
        [HttpGet("{reservationId}/menu-items")]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItemsByReservation(int reservationId)
        {
            var menuItems = await _reservationRepository.GetMenuItemsByReservationIdAsync(reservationId);

            if (menuItems == null || !menuItems.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<MenuItemDto>>(menuItems));
        }

        /// <summary>
        /// Gets orders and menu items by reservation id.
        /// </summary>
        /// <param name="reservationId">The id of the reservation.</param>
        /// <returns>A list of orders and their associated menu items for the specified reservation.</returns>
        [HttpGet("{reservationId}/orders")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByReservation(int reservationId)
        {
            var reservation = await _reservationRepository.GetByIdAsync(reservationId);

            if (reservation == null)
            {
                return NotFound();
            }

            var orders = reservation.Orders;
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }
    }
}