
using Core.Interfaces;
using Infrastructure.Repositories;
using Core.GameContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IGameRepository, GameRepository>();
builder.Services.AddDbContext<GameContext>(options => options.UseSqlServer("server=.\\sqlexpress;db=Checkers;integrated security=true"));
//builder.Services.AddTransient<IPlayerRepository, PlayerRepository>(); // altijd een nieuwe. voordelig qua side effects

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
