using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway_Management_System.Models
{
    public class stationMaster
    {
        [Key]
        public int stationId { get; set; }
        public int stationCode { get; set; }
        public string stationName { get; set; }
        public string stationDivision { get; set; }

        [InverseProperty("stationMaster")] // Define the inverse navigation property
        public List<trainMaster> TrainMasters { get; set; }
    }
}
