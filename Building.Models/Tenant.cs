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
    public  class Tenant
    {
        [Key]
        public int TenantId { get; set; }
        [Required]
        public string TenantName { get; set; }
        [Required]
        public string TenantPhone { get; set; }
        [Required]
        public string Address { get; set; }

        public string? Email { get; set; }
     
        public string? NationalId { get; set; }

        public DateTime RegisterDate { get; set; }
        [Required]
        public int FlatId { get; set; }
        [ForeignKey("FlatId")]
        [ValidateNever]
        public Flat Flat { get; set; } // Navigation property to Flat

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        [ValidateNever]
        public Status Status { get; set; } // Navigation property to Status
    }
}
