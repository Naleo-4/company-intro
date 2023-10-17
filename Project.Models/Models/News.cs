using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? NewsBody { get; set; }
        public string? Image { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
