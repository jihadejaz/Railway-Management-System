using System.ComponentModel.DataAnnotations;

namespace Railway_Management_System.Models
{
    public class RMSpassengers
    {
        [Key]
        public int Passenger_Id { get; set; }
        [Required]
        public string User_name { get; set; }
        [Required]
        public string Password { get; set; } = "rms2023";
        public string Role { get; set; } = "User";


    }
}
