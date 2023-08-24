using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI_5._0.Models;
using RestaurantAPI_5._0.Services;
using System.Collections.Generic;

namespace RestaurantAPI_5._0.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;
        public DishController(IDishService dishService)
        {
            _dishService = dishService;

        }

        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get([FromRoute] int restaurantId, [FromRoute]int dishId)
        {
            DishDto dish = _dishService.GetById(restaurantId, dishId);
            return Ok(dish);
        }

        [HttpGet]
        public ActionResult<List<DishDto>> Get([FromRoute] int restaurantId)
        {
            var listOfDishes = _dishService.GetAll(restaurantId);
            return Ok(listOfDishes);
        }

        [HttpPost]
        public ActionResult Post([FromRoute]int restaurantId, [FromBody] CreateDishDto dto)
        {
            var newDishId = _dishService.Create(restaurantId,dto);
            return Created($"api/restaurant/{restaurantId}",null);
        }

        [HttpDelete]
        public ActionResult DeleteAll([FromRoute] int restaurantId)
        {
            _dishService.RemoveAll(restaurantId);
            return NoContent();
        }

        [HttpDelete("{dishId}")]
        public ActionResult Delete([FromRoute] int restaurantId, [FromRoute]int dishId)
        {
            _dishService.Remove(restaurantId,dishId);
            return NoContent();
        }

    }
}
