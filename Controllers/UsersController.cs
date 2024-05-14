//using Context.Data;
//using eatsy_21._03._2024.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Extensions;
//using System.Web.Http.ModelBinding;

//namespace eatsy_21._03._2024.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly DataContext dbContext;
//        public UsersController(DataContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }
//        [HttpPost]
//        [Route("Registration")]
//        public IActionResult Registration(UserDTO userDTO)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            var objUser = dbContext.Users.FirstOrDefault(x => x.Email == userDTO.Email);
//            if (objUser == null)
//            {
//                dbContext.Users.Add(new User
//                {
//                    Name = userDTO.Name,
//                    Email = userDTO.Email,
//                    Password = userDTO.Password,
//                });
//                dbContext.SaveChanges();
//                return Ok("User registered succesfully");
//            }
//            else
//            {
//                return BadRequest("User already exist with the same email adress.");
//            }
//        }
//        [HttpPost]
//        [Route("Login")]
//        public IActionResult Login(LoginDTO loginDTO)
//        {
//            var user = dbContext.Users.FirstOrDefault(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);
//            if (user != null)
//            {
//                return Ok(user);
//            }
//            return NoContent();

//        }
//        [HttpGet]
//        [Route("GetUsers")]
//        public IActionResult GetUsers()
//        {
//            return Ok(dbContext.Users.ToList());
//        }
//        [HttpGet]
//        [Route("GetUser")]
//        public IActionResult GetUser(int id)
//        {
//            var user = dbContext.Users.FirstOrDefault(x => x.UserId == id);
//            if (user != null)
//                return Ok(user);
//            else
//                return NoContent();

//        }
//[HttpPost]
//[Route("Restaurants Search")]
//public IActionResult Search(string searchTerm)
//{
//	var searchResults = dbContext.Restaurants
//		.Where(r => r.Name.Contains(searchTerm) || r.Address.Contains(searchTerm))
//		.ToList();

//	return Ok(searchResults);
//}
//[HttpPost]
//[Route("Send Submit")]
//public IActionResult Submit(string feedback)
//{
//	var newFeedback = new Feedback { Message = feedback };

//	dbContext.Feedbacks.Add(newFeedback);
//	dbContext.SaveChanges();

//	return RedirectToAction("Confirmation");
//}
//    }
//}

using Context.Data;
using eatsy_21._03._2024.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.OpenApi.Extensions;
using System.Web.Http.ModelBinding;
using eatsy_21._03._2024.Services;

namespace eatsy_21._03._2024.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly DataContext dbContext;
		public UsersController(DataContext dbContext)
		{
			this.dbContext = dbContext;
		}
		[HttpPost]
		[Route("Registration")]
		public IActionResult Registration(UserDTO userDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var objUser = dbContext.Users.FirstOrDefault(x => x.Email == userDTO.Email);
			if (objUser == null)
			{
				dbContext.Users.Add(new User
				{
					Name = userDTO.Name,
					Email = userDTO.Email,
					Password = userDTO.Password,
				});
				dbContext.SaveChanges();
				return Ok("User registered succesfully");
			}
			else
			{
				return BadRequest("User already exist with the same email adress.");
			}
		}
		[HttpPost]
		[Route("Login")]
		public IActionResult Login(LoginDTO loginDTO)
		{
			var user = dbContext.Users.FirstOrDefault(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);
			if (user != null)
			{
				return Ok(user);
			}
			return NoContent();

		}

		[HttpGet]
		[Route("GetUsers")]
		public IActionResult GetUsers()
		{
			return Ok(dbContext.Users.ToList());
		}
		[HttpGet]
		[Route("GetUser")]
		public IActionResult GetUser(int id)
		{
			var user = dbContext.Users.FirstOrDefault(x => x.UserId == id);
			if (user != null)
				return Ok(user);
			else
				return NoContent();

		}
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

		[HttpPatch]
		[Route("EditUser")]
		public async Task<ActionResult<UserDTO>> UpdateUser(int id, UserDTO updatedUser)
		{
			try
			{
				var user = await this.dbContext.Users.FindAsync(id);

				if (user != null)
				{
					user.Email = updatedUser.Email;
					user.Password = updatedUser.Password;
					user.Name = updatedUser.Name;
					await this.dbContext.SaveChangesAsync();
					return Ok(updatedUser);
				}
				return NotFound();

			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}

		}

	}
}
