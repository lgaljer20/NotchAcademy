using cassiopeia_be.Business.Interfaces;
using cassiopeia_be.Business.Services;
using cassiopeia_be.Data;
using Microsoft.EntityFrameworkCore;

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

app.Run();
