using System.ComponentModel.DataAnnotations;

namespace StradaAPI.Model
{
	public class User
	{
        public User()
        {
            Employments = new List<Employment>();
        }

        /// <summary>
        /// ID is uinique identity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name and it is required
        /// </summary>
        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Last name and it is required
        /// </summary>
        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; } 

        /// <summary>
        /// Email address and it is unique and required
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        /// <summary>
        /// Home address
        /// </summary>
        public Address? Address { get; set; }

        /// <summary>
        /// list of employments
        /// </summary>
        public List<Employment> Employments { get; set; }
    }
}

