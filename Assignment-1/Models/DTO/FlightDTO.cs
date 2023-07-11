using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models.DTO
{
	public class FlightDTO
	{
		
		public int Id { get; set; }

		
		[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]

		public string FlightCode { get; set; }

		[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]

		public string AirlineCode { get; set; }


		[RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed.")]

		public string FlightName { get; set; }
	}
}
