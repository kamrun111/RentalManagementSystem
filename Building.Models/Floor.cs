using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Building.Models
{
    public class Floor
    {
        [Key]
        public int FloorId { get; set; }
        [Required(ErrorMessage = "FlatName is required")]
        [MaxLength(30)]
        public string FloorName { get; set; }





        
    }
}
