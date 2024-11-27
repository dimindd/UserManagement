using Microsoft.EntityFrameworkCore;
using UserManagementApp.Application.Interfaces;
using UserManagementApp.Application.Services;
using UserManagementApp.Infrastructure;
using UserManagementApp.Infrastructure.Repositories;
using AutoMapper;
using UserManagementApp.Application.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); 
        c.RoutePrefix = string.Empty;  
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
