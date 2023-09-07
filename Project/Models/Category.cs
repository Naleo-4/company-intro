using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        [DisplayName("Created Date Time")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
