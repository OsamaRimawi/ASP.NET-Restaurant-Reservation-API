using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservationAPI.Models
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

    }
}
