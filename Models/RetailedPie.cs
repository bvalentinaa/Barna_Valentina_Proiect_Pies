using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barna_Valentina_Proiect_Pies.Models
{
    public class RetailedPie
    {
        public int RetailerID { get; set; }
        public int PieID { get; set; }
        public Retailer Retailer { get; set; }
        public Pie Pie { get; set; }
    }
}
