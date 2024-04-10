using TodoApi.Models;

namespace TodoApi.Servises.Interface
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> GetRestaurants();
        Task<Restaurant> GetRestaurant();
    }
}
