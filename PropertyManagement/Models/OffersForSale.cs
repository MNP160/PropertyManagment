using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropertyManagement.Models
{
    public class OffersForSale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferId { get; set; }
        public double OfferAmount { get; set; }
        public bool Accepted { get; set; }
        [ForeignKey("user")]
        public string? userId { get; set; }

        //  [ForeignKey("house")]
        // public int Id { get; set; }
        [ForeignKey("house")]
        public int? Id { get; set; }

        public virtual House house { get; set; }

        //[ForeignKey("user")]
      //  public string Id { get; set; }
        public virtual ApplicationUser user { get; set; }
       


    }
}