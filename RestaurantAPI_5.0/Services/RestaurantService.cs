using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI_5._0.Entities;
using RestaurantAPI_5._0.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI_5._0.Services
{
    public interface IRestaurantService
    {
        RestaurantDto GetById(int id);
        IEnumerable<RestaurantDto> GetAll();
        void Create(CreateRestaurantDto dto);
    }

    public class RestaurantService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper)
        {

        }
        public RestaurantDto GetById(int id)
        {
            var restaurant = _dbContext
               .Restaurants
               .Include(r => r.Address)
               .Include(r => r.Dishes)
               .FirstOrDefault(r => r.Id == id);
            if (restaurant is null) return null;

            var result = _mapper.Map<RestaurantDto>(restaurant);
            return result;
        }
        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _dbContext
          .Restaurants
          .Include(r => r.Address)
          .Include(r => r.Dishes)
          .ToList();
            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }
        public void Create(CreateRestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
        }

    }
}
