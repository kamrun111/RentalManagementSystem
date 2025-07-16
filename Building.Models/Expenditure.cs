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
    public class Expenditure
    {
        [Key]
        public int ExpenditureId { get; set; }
        public string? ExpenditureInvoice { get; set; }
        public DateTime ExpenditureDate { get; set; }
        public string? Description { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? Approved { get; set; } = 0;
        public int? ApprovedBy { get; set; }
        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        [ValidateNever]
        public Location Location { get; set; }

        // Navigation property - one expenditure has many details
        [ValidateNever]
        public List<ExpenditureDetail> ExpenditureDetails { get; set; } = new List<ExpenditureDetail>();
    }
}
