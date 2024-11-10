using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservationAPI.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Phone]
        [MaxLength(15)]
        public string Phone { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
                       = new List<Reservation>();

    }
}
