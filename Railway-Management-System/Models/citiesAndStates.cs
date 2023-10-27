using System.ComponentModel.DataAnnotations;

namespace Railway_Management_System.Models
{
    public class citiesAndStates
    {
        [Key]
        public int Id { get; set; }
        public string city { get; set; }
        public string state { get; set; }

    }
}
