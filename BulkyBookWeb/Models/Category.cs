using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set;   }
        [Required]
        public string Name { get; set; }
       
        [DisplayName("Display Order")]
        [Range(1, 10,ErrorMessage ="the display order must be between 1 and 10.")]
        public int DisplayOrder { get; set; }
        public DateTime  CreatedAt { get; set; } = DateTime.Now;
    }
}
