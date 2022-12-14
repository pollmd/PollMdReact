using PollApi.Models;
using Microsoft.EntityFrameworkCore;
using PollApi;
using PollApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbcon = builder.Configuration.GetValue<string>("dbConnectionStrings");
builder.Services.AddDbContext<pollmdContext>(o=>o.UseSqlServer(dbcon));

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ISurveysRepository,SurveysRepository>();

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
