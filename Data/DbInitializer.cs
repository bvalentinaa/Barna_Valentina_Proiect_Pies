using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barna_Valentina_Proiect_Pies.Models;

namespace Barna_Valentina_Proiect_Pies.Data
{
    public class DbInitializer
    {
        public static void Initialize(PieContext context) { 
        context.Database.EnsureCreated();
            if (context.Pies.Any())
            {
                return; // BD a fost creata anterior
            }
            var pies = new Pie[]
            {
                 new Pie{Name="Placinta cu mere",ShortDescription="Prăjitură simplă cu mere rase călite cu zahăr și scorțișoară și aluat fraged",Price=Decimal.Parse("105")},
                 new Pie{Name="Cheesecake cu afine",ShortDescription="Tarta cu blat de biscuiti si crema de mascarpone",Price=Decimal.Parse("118")},
                 new Pie{Name="Placinta cu gutui",ShortDescription="Gustul copilariei intr-o placinta frageda cu umplutura de gutui si nuci",Price=Decimal.Parse("105")}
                 };
            foreach (Pie s in pies)
            {
                context.Pies.Add(s);
            }
    context.SaveChanges();
            var customers = new Customer[]
            {

             new Customer{CustomerID=1050,Name="Barna Valentina",BirthDate=DateTime.Parse("1998-11-06")},
             new Customer{CustomerID=1045,Name="Barna Ana",BirthDate=DateTime.Parse("1968-08-19")},

 };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
context.SaveChanges();
var orders = new Order[]
{
                 new Order{BookID=1,CustomerID=1050},
                 new Order{BookID=3,CustomerID=1045},
                 new Order{BookID=1,CustomerID=1045},
                 new Order{BookID=2,CustomerID=1050},
};
foreach (Order e in orders)
{
    context.Orders.Add(e);
}
context.SaveChanges();
}
    }
}
