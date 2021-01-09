using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barna_Valentina_Proiect_Pies.Models
{
    public class Pie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
