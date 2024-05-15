using eatsy_21._03._2024.Servises.Interface;
using eatsy_21._03._2024.Models;
using Context.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eatsy_21._03._2024.Servises
{
    public class RestaurantService : IRestaurantService
    {
        private readonly DataContext dbContext;
        private readonly List<Restaurants> _restaurants; // Variable for debugging

        public RestaurantService(DataContext dbContext)
        {
            this.dbContext = dbContext;

            // Data for Debugging
            _restaurants = new List<Restaurants> {
                    new Restaurants
                {
                    RestaurantId = 1,
                    Name = "Ресторан 'Смачна кухня'",
                    //WorkingHours = "Пн-Пт: 10:00-22:00, Сб-Нд: 12:00-23:00",
                    Rating = 4.5f,
                    //Description = "Ресторан 'Смачна кухня' пропонує вам широкий вибір страв із різних кухонь світу. Ми гарантуємо вам найсмачніші страви та приємну атмосферу.",
                    //Keywords = "ресторан, їжа, кухня, обід, вечеря",
                    Country = "Україна",
                    City = "Київ",
                    //Address_line1 = "вул. Хрещатик, 1",
                    //Address_line2 = ""
                },new Restaurants
                {
                    RestaurantId = 2,
                    Name = "Піцерія 'Італійська смакота'",
                    //WorkingHours = "Щоденно: 11:00-23:00",
                    Rating = 4.2f,
                    //Description = "Піцерія 'Італійська смакота' пропонує вам справжні італійські піци та італійські страви. Насолоджуйтесь аутентичним смаком Італії у нашому затишному закладі.",
                    //Keywords = "піцерія, піца, італійська кухня, обід, вечеря",
                    Country = "Україна",
                    City = "Львів",
                    //Address_line1 = "вул. Городоцька, 10",
                    //Address_line2 = "ТЦ 'Львів Плаза', поверх 3"
                },new Restaurants
                {
                    RestaurantId = 3,
                    Name = "Стейкхаус 'М'ясо і Вогонь'",
                    //WorkingHours = "Пн-Сб: 12:00-00:00, Нд: 12:00-22:00",
                    Rating = 4.7f,
                    //Description = "Стейкхаус 'М'ясо і Вогонь' пропонує вам найсмачніші стейки та м'ясні страви, які готуються на відкритому вогні. Насолоджуйтесь неперевершеним смаком м'яса у нашому затишному закладі.",
                    //Keywords = "стейкхаус, стейк, м'ясо, вогонь, обід, вечеря",
                    Country = "Україна",
                    City = "Одеса",
                    //Address_line1 = "вул. Дерибасівська, 15",
                    //Address_line2 = ""
                }, new Restaurants
                {
                    RestaurantId = 4,
                    Name = "Суші-бар 'Вишукані смаки'",
                    //WorkingHours = "Пн-Нд: 12:00-22:30",
                    Rating = 4.3f,
                    //Description = "Суші-бар 'Вишукані смаки' пропонує вам різноманітні суші, саші та інші японські страви. Спробуйте справжні смаки Японії у нашому сучасному закладі.",
                    //Keywords = "суші, саші, японська кухня, обід, вечеря",
                    Country = "Україна",
                    City = "Харків",
                    //Address_line1 = "пр. Науки, 21",
                    //Address_line2 = "ТЦ 'Метрополіс', поверх 2"
                },new Restaurants
                {
                    RestaurantId = 5,
                    Name = "Французький бістро 'Ле Петіт Кафе'",
                    //WorkingHours = "Пн-Пт: 08:00-22:00, Сб-Нд: 10:00-23:00",
                    Rating = 4.6f,
                    //Description = "Французький бістро 'Ле Петіт Кафе' пропонує вам аутентичні французькі страви та вишукані десерти. Проведіть час у приємній атмосфері Франції у нашому затишному бістро.",
                    //Keywords = "французька кухня, бістро, обід, вечеря, десерти",
                    Country = "Україна",
                    City = "Київ",
                    //Address_line1 = "вул. Липки, 10",
                    //Address_line2 = ""
                }
            };
        }

        public async Task<IEnumerable<Restaurants>> GetItems()
        {
            var restaurants = await this.dbContext.Restaurants.ToListAsync();
            //return restaurants;
            return _restaurants; // Return restaurants from data for debugging
        }

        public async Task<Restaurants> GetItem(int id)
        {
            //var restaurant = await this.dbContext.Restaurants.SingleOrDefaultAsync(p => p.RestaurantId == id);
             var restaurant = _restaurants.Where(r => r.RestaurantId == id).SingleOrDefault(); // Get restaurant from data for debugging
            return restaurant;
        }

        public async Task<IEnumerable<Restaurants>> GetFilteredRestaurants(RestaurantFilterDTO filterDTO)
        {
            // Filtering restaurants by conditions
            var filteredRestaurants = await GetItems();

            // Name filtering
            if (!string.IsNullOrEmpty(filterDTO.Name))
            {
                filteredRestaurants = filteredRestaurants.Where(r => r.Name.Contains(filterDTO.Name, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // City filtering
            if (!string.IsNullOrEmpty(filterDTO.City))
            {
                filteredRestaurants = filteredRestaurants.Where(r => r.City.Equals(filterDTO.City, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Country filtering
            if (!string.IsNullOrEmpty(filterDTO.Country))
            {
                filteredRestaurants = filteredRestaurants.Where(r => r.Country.Equals(filterDTO.Country, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Rating filtering
            if (filterDTO.MinRating.HasValue)
            {
                filteredRestaurants = filteredRestaurants.Where(r => r.Rating >= filterDTO.MinRating).ToList();
            }

            return filteredRestaurants;
        }
    }
}
