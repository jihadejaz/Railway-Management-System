using System.ComponentModel.DataAnnotations;

namespace Railway_Management_System.Models
{
    public class trainInformation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string distance { get; set; }
        [Required]
        public string typeOfCompartment { get; set;}
        [Required]
        public string typeOfTrain { get; set; }
    }
}
