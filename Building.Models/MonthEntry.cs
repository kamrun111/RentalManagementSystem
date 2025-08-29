using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.VisualBasic;

namespace Building.Models
{
    public class MonthEntry
    {

        [Key]
        public int MonthEntryId { get; set; }
        public string MonthName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Type is required")]

        public int? TypeIdentifierId { get; set; }

        [ForeignKey("TypeIdentifierId")]
        [ValidateNever]
        public TypeIdentifier TypeIdentifier { get; set; }
        public int Status { get; set; }
        public DateTime? Record_creted_date { get; set; }

    }
}
