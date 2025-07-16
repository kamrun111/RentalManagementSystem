using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Models
{
    public  class FlatType
    {
        [Key]
        public int FlatTypeId { get; set; }
        public string Type { get; set; }
    }
}
