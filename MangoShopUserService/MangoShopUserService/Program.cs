using MangoShopUserService;
using MangoShopUserService.Model;
using MangoShopUserService.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var AppConfig = builder.Configuration;

IConfigurationSection configuration = AppConfig.GetSection("ConnectionStrings");
string connectionString = configuration.GetSection("Data").Value;

builder.Services.AddAutoMapper(typeof(ProfileMap));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PermissionService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Database.Migrate();

    if (!context.Permissions.Any())
    {
        context.Permissions.AddRange(
                new Permission { Id = 1, PermissionName = "Worker" },
                new Permission { Id = 2, PermissionName = "Admin" },
                new Permission { Id = 3, PermissionName = "User" }
            );

    }
    if (!context.Users.Any())
    {
        context.Users.AddRange(
                new User { Id = 1, Name = "admin", Email = "admin@gmail.com", Password = "123", PermissionId = 2, PostalCode = "00-000", Street = "oooo", Country = "oooo", City = "oooo" },
                new User { Id = 2, Name = "misha", Email = "misha@gmail.com", Password = "misha", PermissionId = 3, PostalCode = "00-000", Street = "oooo", Country = "oooo", City = "oooo" }
            );

    }
    context.SaveChanges();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
