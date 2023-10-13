using System.ComponentModel.DataAnnotations;

namespace Railway_Management_System.Models
{
    public class RMScomplaints
    {
        [Key]
        public int complaintId { get; set; }
        [Required]

        public string complaintName { get; set; }
        [Required]
        public string complaintType { get; set; }
        [Required]
        public string complaintDescription { get; set; }

    }
}
