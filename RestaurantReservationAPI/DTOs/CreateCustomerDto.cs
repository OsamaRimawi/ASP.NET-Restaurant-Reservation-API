using System.ComponentModel.DataAnnotations;

namespace RestaurantReservationAPI.DTOs
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(15, ErrorMessage = "Phone number cannot exceed 15 characters.")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Phone number is not valid.")]
        public string Phone { get; set; } = string.Empty;
    }
}