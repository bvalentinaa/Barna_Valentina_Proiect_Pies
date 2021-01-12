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
                 new Pie{Name="Placinta cu gutui",ShortDescription="Gustul copilariei intr-o placinta frageda cu umplutura de gutui si nuci",Price=Decimal.Parse("135")},
                 new Pie{Name="Tarta cu lapte condensat si lime",ShortDescription="O prajitura racoritoare, fara coacere si cu o combinatie de gusutri interesanta",Price=Decimal.Parse("115")},
                 new Pie{Name="Placinta cu dovleac",ShortDescription="Dovleacul placintar este ingredintul perfect pentru o placinta cu gust de toamna",Price=Decimal.Parse("100")},
                 new Pie{Name="Cheesecake cu oreo",ShortDescription="Indragita atat de cei mici cat si de cei mari",Price=Decimal.Parse("108")},
                 new Pie{Name="Tarta cu marar",ShortDescription="Tarta cu marar aduce impreuna gusturile de urda si marar proaspete",Price=Decimal.Parse("113")},
                 new Pie{Name="Placinta cu varza",ShortDescription="Aluat pufos umplut cu varza a la Cluj",Price=Decimal.Parse("98")},
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
                 new Order{PieID=1,CustomerID=1053,OrderDate=DateTime.Parse("10-28-2020")},
                 new Order{PieID=3,CustomerID=1045,OrderDate=DateTime.Parse("11-28-2020")},
                 new Order{PieID=4,CustomerID=1045,OrderDate=DateTime.Parse("10-21-2020")},
                 new Order{PieID=2,CustomerID=1050,OrderDate=DateTime.Parse("12-10-2020")},
                 new Order{PieID=6,CustomerID=1052,OrderDate=DateTime.Parse("06-11-2020")},
                 new Order{PieID=5,CustomerID=1052,OrderDate=DateTime.Parse("09-12-2020")},
};
foreach (Order e in orders)
{
    context.Orders.Add(e);
}
context.SaveChanges();
            var retailers = new Retailer[]
 {

 new Retailer{RetailerName="Mama Luta",Adress="Str. Principala, nr. 40, Ampoita"},
 new Retailer{RetailerName="CorinaSweets",Adress="Str. Motilor, nr. 35, Alba-Iulia"},
 new Retailer{RetailerName="Byron",Adress="Str. 1Decembrie, nr. 22, Alba-Iulia"},
 };
            foreach (Retailer p in retailers)
            {
                context.Retailers.Add(p);
            }
            context.SaveChanges();
            var retailedpies = new RetailedPie[]
            {
 new RetailedPie {
 PieID = pies.Single(c => c.Name == "Placinta cu varza" ).ID,
 RetailerID = retailers.Single(i => i.RetailerName ==
"Mama Luta").ID
 },
 new RetailedPie {
 PieID = pies.Single(c => c.Name == "Placinta cu mere" ).ID,
RetailerID = retailers.Single(i => i.RetailerName ==
"Mama Luta").ID
 },
 new RetailedPie {
 PieID = pies.Single(c => c.Name == "Cheesecake cu oreo" ).ID,
 RetailerID = retailers.Single(i => i.RetailerName ==
"CorinaSweets").ID
 },
 new RetailedPie {
 PieID = pies.Single(c => c.Name == "Cheesecake cu afine" ).ID,
RetailerID = retailers.Single(i => i.RetailerName == "CorinaSweets").ID
 },
 new RetailedPie {
 PieID = pies.Single(c => c.Name == "Tarta cu lapte condensat si lime" ).ID,
RetailerID = retailers.Single(i => i.RetailerName == "Byron").ID
 },
 new RetailedPie {PieID = pies.Single(c => c.Name == "Placinta cu gutui" ).ID, RetailerID = retailers.Single(i => i.RetailerName == "Byron").ID
 },
 new RetailedPie {PieID = pies.Single(c => c.Name == "Placinta cu dovleac" ).ID, RetailerID = retailers.Single(i => i.RetailerName == "Byron").ID
 },
 new RetailedPie {PieID = pies.Single(c => c.Name == "Tarta cu marar" ).ID, RetailerID = retailers.Single(i => i.RetailerName == "Mama Luta").ID
 },
 };
            foreach (RetailedPie pb in retailedpies)
            {
                context.RetailedPies.Add(pb);
            }
            context.SaveChanges();
        }
    }
}
