using eatsy_21._03._2024.Models;
namespace eatsy_21._03._2024.Servises.Interface
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurants>> GetItems();
        Task<Restaurants> GetItem(int id);
        Task<IEnumerable<Restaurants>> GetFilteredRestaurants(RestaurantFilterDTO filterDTO);
    }
}
