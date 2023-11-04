using System.ComponentModel.DataAnnotations;

namespace Railway_Management_System.Models
{
    public class compositeModel
    {

        //DATA FETCHED FROM CONTROLLER 

        public List<citiesAndStates> CitiesAndStates { get; set; }
        public List<trainMaster> TrainMasters { get; set; }

        public List<stationMaster> stationMasters { get; set; }



        //FARE CALCULATION FIELDS 

        [Required]
        public string selectTrain { get; set; }
        [Required]

        public string fromCity { get; set; }
        [Required]

        public string toCity { get; set; }

        //TRAIN SEARCH FIELDS 

        [Required]
        public string from { get; set; }
        [Required]
        public string to { get; set; }
        [Required]
        public int trainDate { get; set; }

        

        //FARE DETAILS 

        [Key]
        public int Id { get; set; }
        [Required]
        public int distance { get; set; }

        [Required]
        public string compartment { get; set; }
        [Required]

        public string typeOfTrain { get; set; }



        [Key]
        public int PNR_no { get; set; }

        [Required]
        public string passengerName { get; set; }

        [Required]

        public int age { get; set; }

        [Required]

        public string gender { get; set; }
        [Required]

        public int totalPassengers { get; set; }
        [Required]

        public DateTime dateOfTravel { get; set; }
        [Required]

        public string trainCategory { get; set; }
        [Required]

        public string trainNumber { get; set; }


    }
}
