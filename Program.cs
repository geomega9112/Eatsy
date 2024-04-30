using eatsy_21._03._2024.Models;
using Microsoft.EntityFrameworkCore; //
using TodoApi.Models;
//

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


//builder.Services.AddDbContextPool<WeatherForecastContext>(
//    o => o.UseSqlServer(builder.Configuration.GetConnectionString("WeatherForecastContext")));

//builder.Services.AddDbContext<TodoContext>(opt =>           //builder.Services.AddDbContext<TestData>(opt => //
//	opt.UseInMemoryDatabase("TodoList"));                   //	opt.UseInMemoryDatabase("TodoList")); //

builder.Services.AddDbContext<TodoContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("TodoContext")));
//builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapGet("/todoitems", async (TodoContext db) =>
	await db.Todos.ToListAsync());

app.MapGet("/todoitems/complete", async (TodoContext db) =>
	await db.Todos.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, TodoContext db) =>
	await db.Todos.FindAsync(id)
		is TodoItem todo
			? Results.Ok(todo)
			: Results.NotFound());

app.MapPost("/todoitems", async (TodoItem /* DTO ?*/ todo, TodoContext db) =>
{
	db.Todos.Add(todo);
	await db.SaveChangesAsync();

	return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/todoitems/{id}", async (int id, TodoItem inputTodo, TodoContext db) =>
{
	var todo = await db.Todos.FindAsync(id);

	if (todo is null) return Results.NotFound();

	todo.Name = inputTodo.Name;
	todo.IsComplete = inputTodo.IsComplete;

	await db.SaveChangesAsync();

	return Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (int id, TodoContext db) =>
{
	if (await db.Todos.FindAsync(id) is TodoItem todo)
	{
		db.Todos.Remove(todo);
		await db.SaveChangesAsync();
		return Results.NoContent();
	}

	return Results.NotFound();
});


///////////////////////////////////////////////////////////////////////////////////////////
app.UseHttpsRedirection(); 

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
