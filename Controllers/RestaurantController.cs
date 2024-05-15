using Microsoft.AspNetCore.Mvc;
using eatsy_21._03._2024.Servises.Interface;
using eatsy_21._03._2024.Models;


namespace eatsy_21._03._2024.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        [Route("GetRestaurants")]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> GetRestaurants()
        {
            var data = await _restaurantService.GetItems();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetRestaurant")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurant(int id)
        {
            try
            {
                var restaurant = await this._restaurantService.GetItem(id);
                return restaurant == null ? BadRequest() : Ok(restaurant);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpPost("Filter")]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> GetFilteredRestaurants([FromBody] RestaurantFilterDTO filterDto)
        {
            try
            {
                var filteredRestaurants = await _restaurantService.GetFilteredRestaurants(filterDto);
                return filteredRestaurants == null ? BadRequest() : Ok(filteredRestaurants);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

    }
}
