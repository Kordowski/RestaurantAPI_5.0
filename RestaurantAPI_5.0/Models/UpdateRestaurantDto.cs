using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI_5._0.Models
{
    public class UpdateRestaurantDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasDelivery { get; set; }
    }
}
