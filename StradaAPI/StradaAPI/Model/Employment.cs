using System.ComponentModel.DataAnnotations;
namespace StradaAPI.Model
{
	public class Employment
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        public string? Company { get; set; }

        [Required(ErrorMessage = "Months of experience is required.")]
        public uint? MonthsOfExperience { get; set; } 

        [Required(ErrorMessage = "Salary is required.")]
        public uint? Salary { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}

