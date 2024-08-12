using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderManagementAPI;
using OrderManagementAPI.Data;
using OrderManagementAPI.Interface;
using OrderManagementAPI.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


// Register DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(5, 6, 46)); // Use your MySQL version
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, serverVersion,
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()));


// Register the repository
builder.Services.AddScoped<ISessionRepository, SessionRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Test Database Connection
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        // Attempt to open a connection
        dbContext.Database.OpenConnection();
        Console.WriteLine("Database connection successful.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection failed: {ex.Message}");
    }
    finally
    {
        // Ensure the connection is closed
        dbContext.Database.CloseConnection();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
