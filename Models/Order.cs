﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barna_Valentina_Proiect_Pies.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int PieID { get; set; }

        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }
        public Pie Pie { get; set; }
    }
}
