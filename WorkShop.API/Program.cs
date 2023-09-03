using Microsoft.EntityFrameworkCore;

using System.Text.Json.Serialization;

using WorkShop.API;
using WorkShop.Business.Http;
using WorkShop.Business.Services;
using WorkShop.Core.Concrete;
using WorkShop.EFCore;
using WorkShop.EFCore.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    //circle ignore
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//json circle ignore

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<Migrate>();
RegisterService.RegisterAPI(builder.Services);

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
using var scope = app.Services.CreateScope();
Migrate? mg = scope.ServiceProvider.GetRequiredService<Migrate>();
mg.MigrateDatabase();

app.Run();