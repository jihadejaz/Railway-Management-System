using System.ComponentModel.DataAnnotations;

namespace Railway_Management_System.Models
{
    public class passengersBooking
    {
        //PASSENGERS BOOKING FIELD 

        [Key]
        public int PNR_no { get; set; }

        [Required]
        public string passengerName { get; set; }

        [Required]

        public int age { get; set; }

        [Required]

        public string gender { get; set; }
        [Required]

        public int totalPassengers { get; set; }
        [Required]

        public DateTime dateOfTravel { get; set; }
        [Required]

        public string trainCategory { get; set; }
        [Required]

        public string trainNumber { get; set; }
    }
}
