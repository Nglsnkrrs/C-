using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingListSystem.Models
{
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } 

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } 

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Связь многие-ко-многим с категориями
        public ICollection<SubscriberCategory> SubscriberCategories { get; set; }
    }
}
