using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.ComponentModel.DataAnnotations;

namespace eatsy_21._03._2024.Models
{
	public class Restaurants
	{
		[Key]
		public int RestaurantId { get; set; } = 0;
		public string Name { get; set; }
		public float Rating { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
	}
}
