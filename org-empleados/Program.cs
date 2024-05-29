using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using org_empleados.Application.Interfaces;
using org_empleados.Application.Services;
using org_empleados.Controllers.V1;
using org_empleados.Domain.Data;
using org_empleados.Domain.Models;
using org_empleados.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionDb = builder.Configuration.GetConnectionString("dbConn");

ArgumentNullException.ThrowIfNull(connectionDb);

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySQL(connectionDb));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
