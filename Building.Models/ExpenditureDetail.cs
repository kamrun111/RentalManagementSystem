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
    public class ExpenditureDetail
    {
        [Key]
        public int ExpenditureDetailId { get; set; }

        public int ExpenditureId { get; set; }
        [ForeignKey("ExpenditureId")]          // Correct FK attribute here
        [ValidateNever]
        public Expenditure Expenditure { get; set; }  // Navigation to parent Expenditure

        public int? ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]          // Correct FK attribute here
        [ValidateNever]
        public Expense Expense { get; set; }  // Navigation to Expense

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Amount { get; set; }
        public string? Remarks { get; set; }
    }
}
