using System.ComponentModel.DataAnnotations;

namespace RestaurantReservationAPI.DTOs
{
    public class CreateReservationDto
    {
        [Required(ErrorMessage = "CustomerId is required.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "EmployeeId is required.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "ReservationDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [FutureDate(ErrorMessage = "ReservationDate must be a future date.")]
        public DateTime ReservationDate { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime > DateTime.Now;
            }
            return false;
        }
    }
}