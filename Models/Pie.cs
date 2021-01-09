using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barna_Valentina_Proiect_Pies.Models
{
    public class Pie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<RetailedPie> RetailedPies { get; set; }
    }
}
