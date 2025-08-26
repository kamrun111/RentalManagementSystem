using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public int? MonthEntryType { get; set; }
        public string Status { get; set; }
        public DateTime Record_creted_date { get; set; }

    }
}
