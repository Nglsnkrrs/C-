using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingListSystem.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(2)]
        public string CountryCode { get; set; }

        public ICollection<Subscriber> Subscribers { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Promotion> Promotions { get; set; }
    }
}
