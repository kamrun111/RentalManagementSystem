using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Building.Models
{
    public class Flat
    {
        public Flat()
        {
            FlatStatus = 0;
        }
        [Key]
        public int FlatId { get; set; }
        [Required(ErrorMessage = "FlatName is required")]
        [MaxLength(30)]
        public string FlatName { get; set; }
        [Required]
        public string FlatSize { get; set; }
        public decimal? FlatRent { get; set; }
        public decimal? ServiceCharge { get; set; }

        [Display(Name = " Property Location")]
        [Required(ErrorMessage = "PropertyName is required")]
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        [ValidateNever]
        public Location Location { get; set; }

        [Display(Name = "Floor")]
        [Required(ErrorMessage = "Floor is required")]
        public int FloorId { get; set; }
        [ForeignKey("FloorId")]
        [ValidateNever]
        public Floor Floor { get; set; }

        [Display(Name = "Flat Type")]
        [Required(ErrorMessage = "PropertyName is required")]
        public int FlatTypeId { get; set; }
        [ForeignKey("FlatTypeId")]
        [ValidateNever]
        public FlatType FlatType { get; set; }
        public int? FlatStatus { get; set; } // 0 for vacant, 1 for occupied


        //// Non-persistent properties to hold additional values from the stored procedure
        //[NotMapped]
        //public string FloorName { get; set; }  // Temporary property for FloorName

        //[NotMapped]
        //public string FlatTypeName { get; set; }  // Temporary property for FlatTypeName

        //[NotMapped]
        //public string LocationName { get; set; }  // Temporary property for LocationName
    }
}
