using System.ComponentModel.DataAnnotations;

namespace StradaAPI.Model
{
	public class User
	{
        public User()
        {
            Employments = new List<Employment>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; } 

        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        public Address? Address { get; set; }

        public List<Employment> Employments { get; set; }
    }
}

