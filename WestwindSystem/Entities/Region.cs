#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Key, Required, StringLength
using System.ComponentModel.DataAnnotations.Schema; //Table
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestwindSystem.Entities
{
    [Table("Regions")]
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        [Required(ErrorMessage = "Region Description is required")]
        [StringLength(50,ErrorMessage = "Region Description limited to 50 characters")]
        public string RegionDescription { get; set; }
    }
}
