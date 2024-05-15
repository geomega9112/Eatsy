using System.Data;
namespace eatsy_21._03._2024.Models
{
	public class User
	{
		public int UserId { get; set; } = 0;
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;
	}
}
