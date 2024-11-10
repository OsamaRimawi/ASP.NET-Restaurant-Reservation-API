using System.ComponentModel.DataAnnotations;

namespace RestaurantReservationAPI.DTOs
{
    public class CreateMenuItemDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 1000.00, ErrorMessage = "Price must be between 0.01 and 1000.00.")]
        public decimal Price { get; set; }
    }
}