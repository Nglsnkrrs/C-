using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games_DB_Version4.Models
{
    public class Games
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PlayingStyle { get; set; }
        public int CopiesSold { get; set; }
        public string GameMode { get; set; }
        public DateTime DateRealise { get; set; }
        public int StudioId { get; set; }

        [ForeignKey("StudioId")]
        public virtual Studio Studio { get; set; }
    }
}