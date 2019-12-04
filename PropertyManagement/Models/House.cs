using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PropertyManagement.Models
{
    public class House
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }


        [Required]
        public int NumberOfRooms { get; set; }

        [Required]
        public int NumberOfBathrooms { get; set; }

        [Required]
        public int NumberOfBedrooms { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Avaibility { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double SalePrice { get; set; }



        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? DateAdded { get; set; }


        [Required]
        public string ExtraInformation { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<OffersForSale> Offers { get; set; }


          

          
        }
}