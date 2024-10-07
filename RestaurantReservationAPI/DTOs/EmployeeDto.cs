namespace RestaurantReservationAPI.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
        public decimal Salary { get; set; }

        public ICollection<ReservationDto> Reservations { get; set; }
               = new List<ReservationDto>();

        public int NumberOfReservations
        {
            get
            {
                return Reservations.Count;
            }
        }


    }
}
