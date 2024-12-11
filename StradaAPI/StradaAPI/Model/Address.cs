using System.ComponentModel.DataAnnotations;

namespace StradaAPI.Model
{
	public class Address
	{
        /// <summary>
        /// ID of the address
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Street Name and it is required
        /// </summary>
        [Required(ErrorMessage = "Street name is required.")]
        public string? Street { get; set; } 

        /// <summary>
        /// City name and it is required
        /// </summary>
        [Required(ErrorMessage = "City name is required.")]
        public string? City { get; set; }

        /// <summary>
        /// postal code
        /// </summary>
        public int? PostCode { get; set; }
    }
}

