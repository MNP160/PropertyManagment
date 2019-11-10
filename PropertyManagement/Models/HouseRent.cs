using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace PropertyManagement.Models
{
    public class HouseRent
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int HouseId { get; set; }


        public DateTime? StartDate { get; set; }
        public DateTime? ScheduledEndDate { get; set; }
     
        [Required]
        public double RentalPrice { get; set; }

       
        [Required]
        public StatusofRentEnum Status { get; set; }

        
        public enum StatusofRentEnum
        {
            Requested,
            Approved,
            Rejected,
            Rented,
           
        }
    }
}