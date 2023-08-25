using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBook.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        public double ListPrice { get; set; }

        [Required]
        [Range(0, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Range(0, 1000)]
        public double Price100 { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Display(Name ="Cover Type")]
        public int CoverTypeId { get; set; }
        [ForeignKey("CoverTypeId")]
        public CoverType CoverType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
