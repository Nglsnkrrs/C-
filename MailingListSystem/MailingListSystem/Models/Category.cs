using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingListSystem.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } 
        public string Description { get; set; }

        public ICollection<SubscriberCategory> SubscriberCategories { get; set; }
        public ICollection<Promotion> Promotions { get; set; }
    }
}
