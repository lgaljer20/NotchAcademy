using cassiopeia_be.Business.Interfaces;
using cassiopeia_be.Business.Services;
using cassiopeia_be.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using static System.Formats.Asn1.AsnWriter;
using Scope = Microsoft.OpenApi.Writers.Scope;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connString = builder.Configuration.GetConnectionString("cassiopeiaDB");

builder.Services.AddDbContext<CassiopeiaContext>(options =>
{
    options.UseSqlServer(connString);
});
builder.Services.AddTransient<ISatelliteInfoService, SatelliteInfoService>();
builder.Services.AddScoped<AprsMessageService>();
builder.Services.AddScoped<ITemperatureDataService, TemperatureDataService>();
builder.Services.AddScoped<IBatteryStatusService, BatteryStatusService>();
builder.Services.AddScoped<IBatteryCurrentService, BatteryCurrentService>();
builder.Services.AddScoped<SatelliteCharacteristicsService>();
builder.Services.AddScoped<ThrusterService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(c => c.AllowAnyHeader().WithMethods("GET", "PUT", "POST", "PATCH", "DELETE", "HEAD", "OPTIONS").AllowAnyOrigin().WithExposedHeaders("Content-Disposition"));
}
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetService<CassiopeiaContext>();
//    await context.Database.MigrateAsync();
//}


app.Run();
