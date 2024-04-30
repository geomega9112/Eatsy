namespace eatsy_21._03._2024.Models
{
	using System.ComponentModel.DataAnnotations;

	//namespace DotnetWebApiWithEFCodeFirst.Models

	public class Customer
	{
		[Key]
		public int CustomerId { get; set; }
		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }
		[Required]
		[MaxLength(50)]
		public string LastName { get; set; }
		[Required]
		[MaxLength(100)]
		public string Email { get; set; }
	}
}
