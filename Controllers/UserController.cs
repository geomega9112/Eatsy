using Context.Data;
using eatsy_21._03._2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eatsy_21._03._2024.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly DataContext dbContext;
        [HttpPost]
        [Route("Restaurants Search")]
        public IActionResult Search(string searchTerm)
        {
            var searchResults = dbContext.Restaurants
              .Where(r => r.Name.Contains(searchTerm) || r.Name.Contains(searchTerm))
              .ToList();

            return Ok(searchResults);
        }
        [HttpPost]
        [Route("Send Submit")]
        public IActionResult Submit(string feedback)
        {
            var newFeedback = new Feedback { Message = feedback };

            dbContext.Feedbacks.Add(newFeedback);
            dbContext.SaveChanges();

            return RedirectToAction("Confirmation");
        }
    }
}
