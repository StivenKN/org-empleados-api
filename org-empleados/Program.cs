using Microsoft.EntityFrameworkCore;
using org_empleados.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionDb = builder.Configuration.GetConnectionString("dbConn");

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySQL(connectionDb));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
