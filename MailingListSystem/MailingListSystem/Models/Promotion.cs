using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingListSystem.Models
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; } 

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [Required]
        public DateTime StartDate { get; set; } 

        [Required]
        public DateTime EndDate { get; set; } 

        public decimal DiscountPercentage { get; set; } 
        public string PromoCode { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
