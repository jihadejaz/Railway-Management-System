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

    /*    [ForeignKey("stationMaster")] // Define the foreign key relationship*/
        [Required]
        public int? routeId { get; set; }

        [Required]
        public string trainCategory { get; set; }


    /*    public stationMaster stationMaster { get; set; } // Navigation property*/
    }
}
