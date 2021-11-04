using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sq5Testing.apipro.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Mobile { get; set; }
    }
}
