using System.ComponentModel.DataAnnotations;

namespace Railway_Management_System.Models
{
    public class trainMaster
    {
        [Key]
        public int trainNumber;

        public string trainName;

        public string status;
    }
}
