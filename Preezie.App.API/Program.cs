using Microsoft.EntityFrameworkCore;
using Preezie.DataAccess.Database;
using Preezie.Services.UsersService;
using Preezie.Solution.ApiFilters;
using Preezie.Solution.AutoMapper;

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

//Add Services
builder.Services.AddScoped(typeof(UsersService));

//Add DTO Mappers
builder.Services.AddAutoMapper(typeof(UserProfile));

var app = builder.Build();

//Seed the initial data for testing
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PreezieContext>();
    if (!context.Users.Any())
    {
        await Seed.SeedData(context);
    }
}

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
