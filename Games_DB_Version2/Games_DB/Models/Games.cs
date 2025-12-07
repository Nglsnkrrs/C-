using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Games_DB.Models
{
    public class Games
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Studio { get; set; }

        public string PlayingStyle { get; set; }  

        public DateTime DateRealise { get; set; }

        public string GameMode { get; set; }
        public int CopiesSold { get; set; }
    }
}
