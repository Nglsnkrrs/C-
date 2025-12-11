using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Games_DB_v3.Models
{
    public class Studio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Branches { get; set; }

        public virtual ICollection<Games> Games { get; set; }
    }
}