using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SelfServiceKiosk.Data;
using SelfServiceKiosk.Models;


var builder = WebApplication.CreateBuilder(args);


//JSON serialization
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SelfServiceKioskDB")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Initialize database with seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); 

        // Ensure admin user exists
        if (!context.Users.Any())
        {
            var adminUser = new User
            {
                Username = "admin",
                Email = "admin@singular.co.za",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                AccountBalance = 0,
                IsActive = true,
                UserRoles = new List<UserRole>
                {
                    new UserRole { RoleId = 1 } // Assign role
                }
            };
            context.Users.Add(adminUser);
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
    }
}

app.Run();