namespace RestaurantReservationAPI.DTOs
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
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
