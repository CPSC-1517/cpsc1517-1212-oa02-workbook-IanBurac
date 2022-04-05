#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // for key
using System.ComponentModel.DataAnnotations.Schema; // for table
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestwindSystem.Entities
{
    [Table("Territories")]
    public class Territory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "TerritoryID is required")]
        [StringLength(maximumLength:20, ErrorMessage = "TerritoryID is limited to 20 characters")]
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }
    }
}
