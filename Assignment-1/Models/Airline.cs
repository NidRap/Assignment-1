using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
	public class Airline
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Sno { get; set; }

		[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
		public string AirlineCode { get; set; }

		[RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed.")]
		public string AirlineName { get; set; }
	}
}
