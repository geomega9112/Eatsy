using Context.Data;
using eatsy_21._03._2024.Models;
using Microsoft.EntityFrameworkCore; //
//

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DataContext");


builder.Services.AddDbContext<DataContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}



////////////////////////////////////////////////////////////////////////////////////////

//app.MapGet("/todoitems", async (DataContext db) =>
//	await db.Todos.ToListAsync());

//app.MapGet("/todoitems/complete", async (TodoContext db) =>
//	await db.Todos.Where(t => t.IsComplete).ToListAsync());

//app.MapGet("/todoitems/{id}", async (int id, DataContext db) =>
//	await db.Todos.FindAsync(id)
//		is TodoItem todo
//			? Results.Ok(todo)
//			: Results.NotFound());

//app.MapPost("/todoitems", async (TodoItem /* DTO ?*/ todo, DataContext db) =>
//{
//	db.Todos.Add(todo);
//	await db.SaveChangesAsync();

//	return Results.Created($"/todoitems/{todo.Id}", todo);
//});

//app.MapPut("/todoitems/{id}", async (int id, TodoItem inputTodo, DataContext db) =>
//{
//	var todo = await db.Todos.FindAsync(id);

//	if (todo is null) return Results.NotFound();

//	todo.Name = inputTodo.Name;
//	todo.IsComplete = inputTodo.IsComplete;

//	await db.SaveChangesAsync();

//	return Results.NoContent();
//});

//app.MapDelete("/todoitems/{id}", async (int id, DataContext db) =>
//{
//	if (await db.Todos.FindAsync(id) is TodoItem todo)
//	{
//		db.Todos.Remove(todo);
//		await db.SaveChangesAsync();
//		return Results.NoContent();
//	}

//	return Results.NotFound();
//});


///////////////////////////////////////////////////////////////////////////////////////////
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();