using System;
using System.ComponentModel.DataAnnotations;

namespace Sq5Testing.apipro.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}
