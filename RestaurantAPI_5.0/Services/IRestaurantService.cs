using Microsoft.AspNetCore.Mvc;
using RestaurantAPI_5._0.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestaurantAPI_5._0.Services
{
    public interface IRestaurantService
    {
        RestaurantDto GetById(int id);
        PagedResult<RestaurantDto> GetAll([FromQuery]RestaurantQuery query);
        int Create(CreateRestaurantDto dto, int userId);
        void Delete(int id);
        void Update(int id, UpdateRestaurantDto dto);
    }
}
