using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.Models.DTO
{
    public class JourneyDTO
    {
        [Required]
        public int Id { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
       
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string AirlineCode { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string FLightCode { get; set; }
        public int NumberOfPassangers { get; set; }
       

        public int FlightID { get; set; }

        public int AirlineID { get; set; }

    }
}
