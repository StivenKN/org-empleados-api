using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using org_empleados.Application.Interfaces;
using org_empleados.Application.Services;
using org_empleados.Domain.Data;
using org_empleados.Domain.Models;
using org_empleados.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddW3CLogging(logging =>
{
    logging.LoggingFields = W3CLoggingFields.All;

    logging.AdditionalRequestHeaders.Add("x-forwarded-for");
    logging.AdditionalRequestHeaders.Add("x-client-ssl-protocol");
    logging.FileSizeLimit = 5 * 1024 * 1024;
    logging.RetainedFileCountLimit = 2;
    logging.FileName = "MyLogFile";
    logging.FlushInterval = TimeSpan.FromSeconds(2);
});

// Add services to the container.
string? connectionDb = builder.Configuration.GetConnectionString("dbConn");

ArgumentNullException.ThrowIfNull(connectionDb);

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySQL(connectionDb));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
builder.Services.AddAuthorization();
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MiPoliticaCORS", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseW3CLogging();

app.UseCors("MiPoliticaCORS");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
