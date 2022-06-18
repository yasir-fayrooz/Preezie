using Microsoft.EntityFrameworkCore;
using Preezie.DataAccess.Database;
using Preezie.Services.UsersService;
using Preezie.Solution.ApiFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    //Add custom exception filter for handling error responses in a clean way ;)
    options.Filters.Add(typeof(CustomExceptionFilter));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DB Connection
builder.Services.AddDbContext<PreezieContext>(opt => opt.UseInMemoryDatabase("PreezieDb"));

//Add Services/Singletons
builder.Services.AddSingleton(typeof(UsersService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    //Allow API to be hit from anywhere for testing purposes
    app.UseCors(opt => {
        opt.AllowAnyHeader();
        opt.AllowAnyMethod();
        opt.AllowAnyOrigin();
    });
}

//Seed the initial data for testing
var context = app.Services.GetService<PreezieContext>();
if (!context.Users.Any())
{
    await Seed.SeedData(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
