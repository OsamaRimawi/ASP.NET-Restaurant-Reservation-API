namespace RestaurantReservationAPI.DTOs
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }

        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ReservationDate { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
                = new List<OrderDto>();

        public int NumberOfOrders
        {
            get
            {
                return Orders.Count;
            }
        }


    }
}
