using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.Models.DTO
{
	public class AirlineDTO
	{
		[Required]

        public int Sno { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
		public string AirlineCode { get; set; }

		[RegularExpression("^[a-zA-Z' ']*$", ErrorMessage = "Only Alphabets allowed.")]
		public string AirlineName { get; set; }
	}
}
