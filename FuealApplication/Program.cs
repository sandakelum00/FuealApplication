using FuealApplication.Models;
using FuealApplication.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<StationStoreDatabaseSettings> (
builder.Configuration.GetSection(nameof(StationStoreDatabaseSettings)));

builder.Services.AddSingleton<IStationStoreDatabaseSettings>(sp =>
sp.GetRequiredService<IOptions<StationStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("StationStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IStationServices, StationService>();

builder.Services.AddControllers();
 //Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


