using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Barna_Valentina_Proiect_Pies.Models
{
    public class Retailer
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Retailer Name")]
        [StringLength(50)]
        public string RetailerName { get; set; }

        [StringLength(70)]
        public string Adress { get; set; }
        public ICollection<RetailedPie> RetailedPies { get; set; }
    }
}
