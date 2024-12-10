using Microsoft.EntityFrameworkCore;
using StradaAPI.Repositories;
using StradaAPI.Services;
using System;

namespace StradaAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add DbContext with SQLite
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=app.db"));

        // Register the UserService, which depends on AppDbContext
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapControllers();

        app.Run();

    }
}

