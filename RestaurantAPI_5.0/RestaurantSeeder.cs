using Bogus;
using RestaurantAPI_5._0.Entities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (!_dbContext.Database.CanConnect())
                return;
            seedRestaurants();
            SeedGeneratedData();
            seedRoles();
            _dbContext.SaveChanges();
        }
        private void seedRoles()
        {
            if (_dbContext.Roles.Any())
                return;
                var roles = GetRoles();
                _dbContext.Roles.AddRange(roles);
        }
        private void seedRestaurants()
        {
            if (_dbContext.Restaurants.Any())
                return;
            var restaurants = GetRestaurants();
            _dbContext.Restaurants.AddRange(restaurants);
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                },
            };
            return roles;
        }
        private void SeedGeneratedData()
        {
            if (_dbContext.Restaurants.Any())
                return;

            var locale = "pl";
            string[] RestaurantCategory = new string[] { "FastFood", "SlowFood", "Barbecue", "Restaurant", "Burgers", "Bar", "Fish_Bar" };
            var addressGenerator = new Faker<Address>(locale)
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Street, f => f.Address.StreetAddress())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());

            var restaurantGenerator = new Faker<Restaurant>(locale)
                .RuleFor(a => a.Name, f => f.Company.CompanyName())
                .RuleFor(a => a.Description, f => f.Company.CatchPhrase())
                .RuleFor(a => a.Address, f => addressGenerator.Generate())
                .RuleFor(a => a.ContactEmail, f =>f.Internet.Email())
                .RuleFor(a => a.ContactNumber, f =>f.Person.Phone)
                .RuleFor(a => a.Category, f => f.PickRandom(RestaurantCategory));

            var users = restaurantGenerator.Generate(95);
            _dbContext.Restaurants.AddRange(users);
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
