using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StradaAPI.Model;
using StradaAPI.Repositories;
using StradaAPI.Services;
using Xunit;

public class UserServiceTests
{
    private AppDbContext CreateInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Filename=:memory:") // Use SQLite in-memory database
            .Options;

        var context = new AppDbContext(options);
        context.Database.OpenConnection(); // Open connection to SQLite
        context.Database.EnsureCreated();  // Ensure schema is created
        return context;
    }

    [Fact]
    public void CreateUser_ValidUser_AddsUserToDatabase()
    {
        // Arrange
        var context = CreateInMemoryDbContext();
        var service = new UserService(context);
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Address = new Address
            {
                Street = "123 Main St",
                City = "Springfield",
                PostCode = 12345
            },
            Employments = new List<Employment>
            {
                new Employment
                {
                    Company = "TechCorp",
                    MonthsOfExperience = 24,
                    Salary = 5000,
                    StartDate = new DateTime(2022, 1, 1),
                    EndDate = new DateTime(2023, 12, 31)
                }
            }
        };

        // Act
        var createdUser = service.CreateUser(user);

        // Assert
        Assert.Equal(1, createdUser.Id); // Ensure Id is generated
        Assert.Equal(1, context.Users.Count());
    }

    [Fact]
    public void CreateUser_DuplicateEmail_ThrowsArgumentException()
    {
        // Arrange
        var context = CreateInMemoryDbContext();
        var service = new UserService(context);
        var user1 = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };
        var user2 = new User
        {
            FirstName = "Jane",
            LastName = "Smith",
            Email = "john.doe@example.com"
        };

        service.CreateUser(user1);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => service.CreateUser(user2));
        Assert.Equal("Email is required and must be unique.", exception.Message);
    }

    [Fact]
    public void GetUserById_ValidId_ReturnsUser()
    {
        // Arrange
        var context = CreateInMemoryDbContext();
        var service = new UserService(context);
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };

        service.CreateUser(user);

        // Act
        var retrievedUser = service.GetUserById(1);

        // Assert
        Assert.NotNull(retrievedUser);
        Assert.Equal("John", retrievedUser.FirstName);
    }

    [Fact]
    public void GetUserById_InvalidId_ThrowsKeyNotFoundException()
    {
        // Arrange
        var context = CreateInMemoryDbContext();
        var service = new UserService(context);

        // Act & Assert
        var exception = Assert.Throws<KeyNotFoundException>(() => service.GetUserById(99));
        Assert.Equal("User not found.", exception.Message);
    }

    [Fact]
    public void UpdateUser_ValidUser_UpdatesDatabase()
    {
        // Arrange
        var context = CreateInMemoryDbContext();
        var service = new UserService(context);
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };

        service.CreateUser(user);

        var updatedUser = new User
        {
            FirstName = "Johnny",
            LastName = "Doe",
            Email = "johnny.doe@example.com"
        };

        // Act
        var result = service.UpdateUser(1, updatedUser);

        // Assert
        Assert.Equal("Johnny", result.FirstName);
        Assert.Equal("johnny.doe@example.com", result.Email);
    }

    [Fact]
    public void UpdateUser_InvalidId_ThrowsKeyNotFoundException()
    {
        // Arrange
        var context = CreateInMemoryDbContext();
        var service = new UserService(context);
        var updatedUser = new User
        {
            FirstName = "Johnny",
            LastName = "Doe",
            Email = "johnny.doe@example.com"
        };

        // Act & Assert
        var exception = Assert.Throws<KeyNotFoundException>(() => service.UpdateUser(99, updatedUser));
        Assert.Equal("User not found.", exception.Message);
    }
}
