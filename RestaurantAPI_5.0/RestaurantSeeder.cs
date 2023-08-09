using RestaurantAPI_5._0.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI_5._0
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
                _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description =
                    " KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in USA",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        }
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                },
                new Restaurant()
                {

                    Name = "McDonalds",
                    Category = "Fast Food",
                    Description =
                    " McDonald is an American fast food restaurant chain headquartered in USA, they serve burgers",
                    ContactEmail = "contact@mcdonalds.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Cheeseburger",
                            Price = 7.30M,
                        },

                        new Dish()
                        {
                            Name = "Hamburger",
                            Price = 4.30M,
                        }
                    },
                    Address = new Address()
                    {
                        City = "Ciechanów",
                        Street = "Armii krajowej 30",
                        PostalCode = "06-400"
                    }
                },

            };
            return restaurants;
        }
    }
}
