using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using eatsy_21._03._2024.Models;
using System.Net;

namespace eatsy_21._03._2024.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodoItemsController : ControllerBase
{
	private readonly TodoContext _context;

	public TodoItemsController(TodoContext context)
	{
		_context = context;
	}

	// GET: api/TodoItems
	[HttpGet]
	public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
	{
		return await _context.TodoItems
			.Select(x => ItemToDTO(x))
			.ToListAsync();
	}

	// GET: api/TodoItems/5
	// <snippet_GetByID>
	[HttpGet("{id}")]
	public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
	{
		var todoItem = await _context.TodoItems.FindAsync(id);

		if (todoItem == null)
		{
			return NotFound();
		}

		return ItemToDTO(todoItem);
	}
	// </snippet_GetByID>

	// PUT: api/TodoItems/5
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	// <snippet_Update>
	[HttpPut("{id}")]
	public async Task<IActionResult> PutTodoItem(long id, TodoItemDTO todoDTO)
	{
		if (id != todoDTO.Id)
		{
			return BadRequest();
		}

		var todoItem = await _context.TodoItems.FindAsync(id);
		if (todoItem == null)
		{
			return NotFound();
		}

		todoItem.Name = todoDTO.Name;
		todoItem.IsComplete = todoDTO.IsComplete;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
		{
			return NotFound();
		}

		return NoContent();
	}
	// </snippet_Update>

	// POST: api/TodoItems
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	// <snippet_Create>
	[HttpPost]
	public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoDTO)
	{
		var todoItem = new TodoItem
		{
			IsComplete = todoDTO.IsComplete,
			Name = todoDTO.Name
		};

		_context.TodoItems.Add(todoItem);
		await _context.SaveChangesAsync();

		return CreatedAtAction(
			nameof(GetTodoItem),
			new { id = todoItem.Id },
			ItemToDTO(todoItem));
	}
	// </snippet_Create>

	// DELETE: api/TodoItems/5
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteTodoItem(long id)
	{
		var todoItem = await _context.TodoItems.FindAsync(id);
		if (todoItem == null)
		{
			return NotFound();
		}

		_context.TodoItems.Remove(todoItem);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool TodoItemExists(long id)
	{
		return _context.TodoItems.Any(e => e.Id == id);
	}

	private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
	   new TodoItemDTO
	   {
		   Id = todoItem.Id,
		   Name = todoItem.Name,
		   IsComplete = todoItem.IsComplete
	   };
}


//public class RequestSetOptionsMiddleware
//{
//	private readonly RequestDelegate _next;

//	public RequestSetOptionsMiddleware(RequestDelegate next)
//	{
//		_next = next;
//	}

//	// Test with https://localhost:5001/Privacy/?option=Hello
//	public async Task Invoke(HttpContext httpContext)
//	{
//		var option = httpContext.Request.Query["option"];

//		if (!string.IsNullOrWhiteSpace(option))
//		{
//			httpContext.Items["option"] = WebUtility.HtmlEncode(option);
//		}

//		await _next(httpContext);
//	}
//}
/////////////////////////////////////////////////////////////////////////////////////////////////////////

//public class MyController // Exemp. controller 
//{
//	private readonly ApplicationDbContext _context;

//	public MyController(ApplicationDbContext context)
//	{
//		_context = context;
//	}
//}

//public class ApplicationDbContext : DbContext
//{
//	private readonly string _connectionString;

//	public ApplicationDbContext(string connectionString)
//	{
//		_connectionString = connectionString;
//	}

//	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//	{
//		optionsBuilder.UseSqlServer(_connectionString);
//	}
//}

