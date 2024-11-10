namespace RestaurantReservationAPI.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int ReservationId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}
