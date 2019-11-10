using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace PropertyManagement.Models
{
    public class HouseSale
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int HouseId { get; set; }


        

        [Required]
        public double SalePrice { get; set; }

       
        
        public StatusofSaleEnum Status { get; set; }

        public enum StatusofSaleEnum
        {
            Requested,
            Approved,
            Rejected,
            Sold,
            
        }
    }
}