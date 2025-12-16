using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_accounting_system.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategryId {  get; set; }
        public bool IsDeleted { get; set; } = false;

        public Category Category { get; set; }
    }
}
