using System.ComponentModel.DataAnnotations;
using StradaAPI.Model;

public class EmploymentValidationTests
{
    private List<ValidationResult> ValidateModel(Employment employment)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(employment);
        Validator.TryValidateObject(employment, context, results, validateAllProperties: true);
        return results;
    }

    [Fact]
    public void Employment_WithAllRequiredFields_ShouldBeValid()
    {
        // Arrange
        var employment = new Employment
        {
            Company = "TechCorp",
            MonthsOfExperience = 24,
            Salary = 5000,
            StartDate = new DateTime(2022, 1, 1),
            EndDate = new DateTime(2023, 12, 31)
        };

        // Act
        var results = ValidateModel(employment);

        // Assert
        Assert.Empty(results); // No validation errors
    }

    [Fact]
    public void Employment_MissingRequiredFields_ShouldReturnValidationErrors()
    {
        // Arrange
        var employment = new Employment
        {
            // Missing Company, MonthsOfExperience, Salary, and StartDate
            EndDate = new DateTime(2023, 12, 31)
        };

        // Act
        var results = ValidateModel(employment);

        // Assert
        Assert.Equal(4, results.Count); // Four required fields are missing
        Assert.Contains(results, r => r.ErrorMessage == "Company name is required.");
        Assert.Contains(results, r => r.ErrorMessage == "Months of experience is required.");
        Assert.Contains(results, r => r.ErrorMessage == "Salary is required.");
        Assert.Contains(results, r => r.ErrorMessage == "Start date is required.");
    }

    [Fact]
    public void Employment_EndDateNotRequired_ShouldBeValidWithoutEndDate()
    {
        // Arrange
        var employment = new Employment
        {
            Company = "TechCorp",
            MonthsOfExperience = 24,
            Salary = 5000,
            StartDate = new DateTime(2022, 1, 1)
            // EndDate is optional
        };

        // Act
        var results = ValidateModel(employment);

        // Assert
        Assert.Empty(results); // No validation errors
    }
}
