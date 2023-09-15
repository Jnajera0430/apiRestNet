using Microsoft.EntityFrameworkCore;
using webapi.Services;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration?.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddNpgsql<ApplicationDbContext>("Host=localhost;Port=5432;Database=taskDb;Username=postgres;Password=syd123;");
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
// {
//     var connectionString = builder.Configuration?.GetConnectionString("DefaultConnection");
//     if (connectionString != null)
//     {
//         options.UseNpgsql(connectionString);
//     }
// });

//builder.Services.AddScoped<IHelloWordService, HelloWorldService>();
builder.Services.AddScoped<IHelloWordService>(_ => new HelloWorldService());
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.useTimeMiddleware();

app.MapControllers();

app.Run();
