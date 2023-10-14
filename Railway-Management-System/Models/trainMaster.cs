using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway_Management_System.Models
{
    public class trainMaster
    {
        [Key]
        public int trainNumber { get; set; }
        public string trainName { get; set; }
        public string status { get; set; }

        [ForeignKey("stationMaster")] // Define the foreign key relationship
        public int routeId { get; set; }
        public string trainCategory { get; set; }

        public stationMaster stationMaster { get; set; } // Navigation property
    }
}
