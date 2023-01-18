using ChessProject.Data;
using ChessProject.Services;
using ChessProject.Hubs;
using ChessProject.Repositories.Interfaces;
using ChessProject.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Blazored.SessionStorage;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<RatingService>();
builder.Services.AddScoped<IGameChatRepository, GameChatRepository>();
builder.Services.AddScoped<GameChatService>();
builder.Services.AddDbContext<ChessDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("Chess")));
builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();


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

app.UseEndpoints(endpoints =>
{
	endpoints.MapBlazorHub();
	endpoints.MapFallbackToPage("/_Host");
	endpoints.MapHub<ChatHub>(ChatClient.HUBURL);
});

app.Run();
