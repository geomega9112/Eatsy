using eatsy_21._03._2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Context.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

    }

}