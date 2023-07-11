using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.Models
{
	public class Flight
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]

		public string FlightCode { get; set; }

		[RegularExpression("^[a-zA-Z0-9]/s*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]

		public string AirlineCode { get; set; }


		[RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed.")]

		public string FlightName { get; set; }


	}
}
