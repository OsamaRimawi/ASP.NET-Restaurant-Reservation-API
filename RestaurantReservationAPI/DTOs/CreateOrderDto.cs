using System.ComponentModel.DataAnnotations;

namespace RestaurantReservationAPI.DTOs
{
    public class CreateOrderDto
    {
        [Required(ErrorMessage = "ReservationId is required.")]
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "MenuItemId is required.")]
        public int MenuItemId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}