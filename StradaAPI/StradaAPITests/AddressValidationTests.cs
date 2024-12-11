using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using StradaAPI.Model;

public class AddressValidationTests
{
    private List<ValidationResult> ValidateModel(Address address)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(address);
        Validator.TryValidateObject(address, context, results, validateAllProperties: true);
        return results;
    }

    [Fact]
    public void Address_WithAllRequiredFields_ShouldBeValid()
    {
        // Arrange
        var address = new Address
        {
            Street = "123 Main St",
            City = "Springfield",
            PostCode = 12345
        };

        // Act
        var results = ValidateModel(address);

        // Assert
        Assert.Empty(results); // No validation errors
    }

    [Fact]
    public void Address_MissingStreet_ShouldReturnValidationError()
    {
        // Arrange
        var address = new Address
        {
            City = "Springfield",
            PostCode = 12345
        };

        // Act
        var results = ValidateModel(address);

        // Assert
        Assert.Single(results); // Only one validation error
        Assert.Contains(results, r => r.ErrorMessage == "Street name is required.");
    }

    [Fact]
    public void Address_MissingCity_ShouldReturnValidationError()
    {
        // Arrange
        var address = new Address
        {
            Street = "123 Main St",
            PostCode = 12345
        };

        // Act
        var results = ValidateModel(address);

        // Assert
        Assert.Single(results); // Only one validation error
        Assert.Contains(results, r => r.ErrorMessage == "City name is required.");
    }

    [Fact]
    public void Address_MissingBothRequiredFields_ShouldReturnValidationErrors()
    {
        // Arrange
        var address = new Address
        {
            PostCode = 12345 // Only PostCode is set
        };

        // Act
        var results = ValidateModel(address);

        // Assert
        Assert.Equal(2, results.Count); // Two validation errors
        Assert.Contains(results, r => r.ErrorMessage == "Street name is required.");
        Assert.Contains(results, r => r.ErrorMessage == "City name is required.");
    }

    [Fact]
    public void Address_PostCodeNotRequired_ShouldBeValidWithoutPostCode()
    {
        // Arrange
        var address = new Address
        {
            Street = "123 Main St",
            City = "Springfield"
            // PostCode is optional
        };

        // Act
        var results = ValidateModel(address);

        // Assert
        Assert.Empty(results); // No validation errors
    }
}
