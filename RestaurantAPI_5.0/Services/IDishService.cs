using RestaurantAPI_5._0.Entities;
using RestaurantAPI_5._0.Models;
using System.Collections.Generic;

namespace RestaurantAPI_5._0.Services
{
    public interface IDishService
    {
        int Create(int restaurantId, CreateDishDto dto);
        DishDto GetById(int restaurantId, int dishId);
        List<DishDto> GetAll(int restaurantId);
        void RemoveAll(int restaurantId);
        void Remove(int restaurantId,int dishId);
    }
}
