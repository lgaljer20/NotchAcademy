
﻿using cassiopeia_be.Business.Interfaces;
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
builder.Services.AddScoped<ITemperatureDataService, TemperatureDataService>();
builder.Services.AddScoped<IBatteryStatusService, BatteryStatusService>();
builder.Services.AddScoped<IBatteryCurrentService, BatteryCurrentService>();


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


