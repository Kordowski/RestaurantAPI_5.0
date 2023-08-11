using System;

namespace RestaurantAPI_5._0.Models
{
    public class ResgiterUserDto
    {
        public  string Email { get; set; }
        public string Password { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth  { get; set; }
    }
}
