using eatsy_21._03._2024.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{

	public class TodoContext : DbContext
	{
		public TodoContext(DbContextOptions<TodoContext> options)
			: base(options)
		{
		}

		public DbSet<TodoItem> Todos { get; set; } = null!;
	}

}