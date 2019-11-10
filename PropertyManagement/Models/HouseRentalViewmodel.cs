using PropertyManagement.Models;
using PropertyManagement.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagement.Models
{
    public class HouseRentalViewmodel
    {
        public int Id { get; set; }

        //House Model Properties
        public int HouseId { get; set; }
        public string Description { get; set; }


        public int NumberOfRooms { get; set; }

      
        public int NumberOfBathrooms { get; set; }

     
        public int NumberOfBedrooms { get; set; }

     
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Range(0, 1000)]
        public int Avaibility { get; set; }


      
        [DataType(DataType.Currency)]
        public double RentalPrice { get; set; }


    
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? DateAdded { get; set; }


    
        public string ExtraInformation { get; set; }

      
        public string Address { get; set; }




        //HouseRent Model Properties
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? StartDate { get; set; }
        [DisplayName("Scheduled End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? ScheduledEndDate { get; set; }

        public string RentalDuration { get; set; }
        public String Status { get; set; }

      

        //Users Model Properties
        public string UserId { get; set; }
        public string Email { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Name { get { return FirstName + " " + LastName; } }
        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? BirthDate { get; set; }
      
    }
}