using Context.Data;
using Microsoft.EntityFrameworkCore;
using eatsy_21._03._2024.Servises;
using eatsy_21._03._2024.Servises.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DataContext");


builder.Services.AddDbContext<DataContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRestaurantService, RestaurantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();




//***IMPORTANT INSTRUCTION HERE - MUST CONFIGURE CONNECTION BEFORE RUNNING MIGRATIONS
//builder.Services.AddDbContextPool<ShopOnlineDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopOnlineConnection"))
//);

//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

//app.UseCors(policy =>
//    policy.WithOrigins("http://localhost:7060", "https://localhost:7060")
//    .AllowAnyMethod()
//    .WithHeaders(HeaderNames.ContentType)
//);