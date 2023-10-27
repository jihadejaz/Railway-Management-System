using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway_Management_System.Models
{
    public class trainMaster
    {
        [Key]
        public int trainNumber { get; set; }
        [Required]
        public string trainName { get; set; }

        [Required(ErrorMessage = "The status field is required.")]
        public string status { get; set; }
        [Required]

        public DateTime departureTime { get; set; }
        [Required]

        public int compartmentNo { get; set; }
        [Required]

        public string trainType {  get; set; }
        [Required]
        public string routeCode { get; set; }

        [Required]
        public string trainCategory { get; set; }

    }
}
