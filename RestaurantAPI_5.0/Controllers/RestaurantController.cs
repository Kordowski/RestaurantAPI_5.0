using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI_5._0.Entities;
using RestaurantAPI_5._0.Models;
using RestaurantAPI_5._0.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace RestaurantAPI_5._0.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
   
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);
            return Ok(restaurant);
        }
        [HttpGet]
        [Authorize(Policy ="Atleast20")]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantsDto = _restaurantService.GetAll();
            return Ok(restaurantsDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        {
           _restaurantService.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]

        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);
            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            var userId = int.Parse(User.FindFirst(c=>c.Type == ClaimTypes.NameIdentifier).Value);
            int id = _restaurantService.Create(dto,userId);
            return Created($"/api/restaurant/{id}", null);
        }

        

        
    }
}
