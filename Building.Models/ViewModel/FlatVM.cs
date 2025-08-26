using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Building.Models.ViewModel
{
    public class FlatVM
    {
        public Flat Flat { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LocationList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> FloorList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TypeList { get; set; }
    }
}
