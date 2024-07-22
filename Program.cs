using Microsoft.EntityFrameworkCore;
using Obqvi_API.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ObqviContext>(options =>
{
    options.UseMySql(conString, ServerVersion.AutoDetect(conString));
    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});

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
