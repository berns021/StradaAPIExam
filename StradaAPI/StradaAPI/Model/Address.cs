using System.ComponentModel.DataAnnotations;

namespace StradaAPI.Model
{
	public class Address
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Street name is required.")]
        public string? Street { get; set; } 

        [Required(ErrorMessage = "City name is required.")]
        public string? City { get; set; }

        public int? PostCode { get; set; }
    }
}

