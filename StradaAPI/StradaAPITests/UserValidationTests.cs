using System.ComponentModel.DataAnnotations;
using StradaAPI.Model;

public class UserValidationTests
{
    private List<ValidationResult> ValidateModel(User user)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(user);
        Validator.TryValidateObject(user, context, results, validateAllProperties: true);
        return results;
    }

    [Fact]
    public void User_WithAllRequiredFields_ShouldBeValid()
    {
        // Arrange
        var user = new User
        {
            FirstName = "Berns",
            LastName = "Caay",
            Email = "berns.caay@testing.com",
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
        var results = ValidateModel(user);

        // Assert
        Assert.Empty(results); // No validation errors
    }

    [Fact]
    public void User_MissingFirstName_ShouldReturnValidationError()
    {
        // Arrange
        var user = new User
        {
            LastName = "Caay",
            Email = "berns.caay@testing.com"
        };

        // Act
        var results = ValidateModel(user);

        // Assert
        Assert.Single(results);
        Assert.Contains(results, r => r.ErrorMessage == "First name is required.");
    }

    [Fact]
    public void User_MissingLastName_ShouldReturnValidationError()
    {
        // Arrange
        var user = new User
        {
            FirstName = "Berns",
            Email = "berns.caay@testing.com"
        };

        // Act
        var results = ValidateModel(user);

        // Assert
        Assert.Single(results);
        Assert.Contains(results, r => r.ErrorMessage == "Last name is required.");
    }

    [Fact]
    public void User_MissingEmail_ShouldReturnValidationError()
    {
        // Arrange
        var user = new User
        {
            FirstName = "Berns",
            LastName = "Caay"
        };

        // Act
        var results = ValidateModel(user);

        // Assert
        Assert.Single(results);
        Assert.Contains(results, r => r.ErrorMessage == "Email is required.");
    }

    [Fact]
    public void User_MissingAllRequiredFields_ShouldReturnValidationErrors()
    {
        // Arrange
        var user = new User
        {
            // No required fields are set
        };

        // Act
        var results = ValidateModel(user);

        // Assert
        Assert.Equal(3, results.Count); // Three required fields are missing
        Assert.Contains(results, r => r.ErrorMessage == "First name is required.");
        Assert.Contains(results, r => r.ErrorMessage == "Last name is required.");
        Assert.Contains(results, r => r.ErrorMessage == "Email is required.");
    }

    [Fact]
    public void User_WithEmptyEmploymentsAndAddress_ShouldBeValid()
    {
        // Arrange
        var user = new User
        {
            FirstName = "Berns",
            LastName = "Caay",
            Email = "berns.caay@testing.com",
            Address = null, // Address is optional
            Employments = new List<Employment>() // No employments
        };

        // Act
        var results = ValidateModel(user);

        // Assert
        Assert.Empty(results); // No validation errors
    }
}
