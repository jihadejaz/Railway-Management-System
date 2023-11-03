using System.ComponentModel.DataAnnotations;


namespace Railway_Management_System.Models
{
    public class searchTrainModel
    {

        //TRAIN SEARCH FIELDS 

        [Required]
        public string from { get; set; }
        [Required]
        public string to { get; set; }
        [Required]
        public int trainDate { get; set; }
    }
}
