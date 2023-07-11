using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.Models
{
    public class Journey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public  DateTime TravelDate { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string AirlineCode { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string FLightCode { get; set; }
        public int NumberOfPassangers { get; set; }


        public Flight Flight { get; set; }
        public Airline Airline { get; set; }

        [ForeignKey("Flight")]

        public int FlightID { get; set; }

        [ForeignKey("Airline")]
        public int AirlineID { get; set; }

    }
}
