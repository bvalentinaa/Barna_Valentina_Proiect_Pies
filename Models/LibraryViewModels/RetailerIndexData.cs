using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barna_Valentina_Proiect_Pies.Models.LibraryViewModels
{
    public class RetailerIndexData
    {
        public IEnumerable<Retailer> Retailers { get; set; }
        public IEnumerable<Pie> Pies { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
