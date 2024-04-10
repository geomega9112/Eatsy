using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using TodoApi.Servises.Interface;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using System.Text.Json.Nodes;

namespace TodoApi.Controllers
{
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetRestaurnts()
        {
            var data = _restaurantService.GetRestaurants();
            return (IHttpActionResult)Ok(data); 
            //return JsonResult(data);
        }

    }
}
