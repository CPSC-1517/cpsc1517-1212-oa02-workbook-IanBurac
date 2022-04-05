using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key]
using System.ComponentModel.DataAnnotations.Schema; // [Table]
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestwindSystem.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(15, ErrorMessage = "Category Name must be 15 or less characters")]
        [Column(TypeName = "CategoryName")]
        public string CategoryName { get; set; } = null!;
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
    }
}
