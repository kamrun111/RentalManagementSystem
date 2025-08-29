using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Models.ViewModel
{
    public class MonthEntryVM
    {
        public MonthEntry MonthEntry { get; set; } = new MonthEntry();
        public IEnumerable<MonthEntry> MonthEntryList { get; set; } = new List<MonthEntry>();

        //public MonthEntry MonthEntry { get; set; }
        //public IEnumerable<MonthEntry> MonthEntryList { get; set; }
    }
}
