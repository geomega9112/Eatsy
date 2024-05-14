using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;

namespace eatsy_21._03._2024.Models
{
	public class RestaurantDTO
	{
		public int RestaurantId { get; set; } = 0;
		public string Name { get; set; }
		public string WorkingHours { get; set; }
		public float Rating { get; set; }
		public string Description { get; set; }
		public string Keywords { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Address_line1 { get; set; }
		public string Address_line2 { get; set; }
	}
}
