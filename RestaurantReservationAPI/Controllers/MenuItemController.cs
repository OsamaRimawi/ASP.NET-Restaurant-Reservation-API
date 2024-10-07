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
    [Route("api/menu-items")]
    public class MenuItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemController(IMapper mapper, IMenuItemRepository menuItemRepository)
        {
            _mapper = mapper;
            _menuItemRepository = menuItemRepository;
        }

        /// <summary>
        /// Gets a list of all menu items.
        /// </summary>
        /// <returns>A list of menu items.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItems()
        {
            var menuItems = await _menuItemRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<MenuItemDto>>(menuItems));
        }

        /// <summary>
        /// Gets a menu item by id.
        /// </summary>
        /// <param name="id">The id of the menu item to get.</param>
        /// <response code="200">Returns the requested menu item.</response>
        /// <response code="404">If the menu item is not found.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <returns>A menu item.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MenuItemDto>> GetMenuItem(int id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MenuItemDto>(menuItem));
        }

        /// <summary>
        /// Creates a new menu item.
        /// </summary>
        /// <param name="menuItemDto">The menu item data transfer object.</param>
        /// <returns>The created menu item.</returns>
        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem(CreateMenuItemDto menuItemDto)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemDto);

            await _menuItemRepository.AddAsync(menuItem);

            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.MenuItemId }, menuItem);
        }

        /// <summary>
        /// Updates an existing menu item.
        /// </summary>
        /// <param name="id">The id of the menu item to update.</param>
        /// <param name="menuItemDto">The menu item data transfer object.</param>
        /// <response code="204">If the update is successful.</response>
        /// <response code="404">If the menu item is not found.</response>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutMenuItem(int id, CreateMenuItemDto menuItemDto)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            _mapper.Map(menuItemDto, menuItem);

            await _menuItemRepository.UpdateAsync(menuItem);

            return NoContent();
        }

        /// <summary>
        /// Deletes a menu item by id.
        /// </summary>
        /// <param name="id">The id of the menu item to delete.</param>
        /// <response code="204">If the deletion is successful.</response>
        /// <response code="404">If the menu item is not found.</response>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            await _menuItemRepository.DeleteAsync(menuItem);

            return NoContent();
        }
    }
}