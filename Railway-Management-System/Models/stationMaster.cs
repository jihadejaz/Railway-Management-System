using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway_Management_System.Models
{
    public class stationMaster
    {
        [Key]
        public int stationId { get; set; }

        [Required(ErrorMessage = "The station code field is required.")]
        public string stationCode { get; set; }
        [Required]
        public string stationName { get; set; }
        [Required]
        public string stationDivision { get; set; }

      /*  [InverseProperty("stationMaster")] // Define the inverse navigation property
        public List<trainMaster> TrainMasters { get; set; }*/
    }
}
