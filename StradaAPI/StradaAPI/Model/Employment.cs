using System.ComponentModel.DataAnnotations;
namespace StradaAPI.Model
{
	public class Employment
	{
        /// <summary>
        /// Id of each employement
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Company name and it is required
        /// </summary>
        [Required(ErrorMessage = "Company name is required.")]
        public string? Company { get; set; }

        /// <summary>
        /// Months of experience it is requires
        /// </summary>
        [Required(ErrorMessage = "Months of experience is required.")]
        public uint? MonthsOfExperience { get; set; } 

        /// <summary>
        /// Salary it is required
        /// </summary>
        [Required(ErrorMessage = "Salary is required.")]
        public uint? Salary { get; set; }

        /// <summary>
        /// Start date and it is required
        /// </summary>
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// End date must be greather than start date
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}

