using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Barna_Valentina_Proiect_Pies.Models;
using Barna_Valentina_Proiect_Pies.Models.LibraryViewModels;
using Barna_Valentina_Proiect_Pies.Data;
using Microsoft.EntityFrameworkCore;

namespace Barna_Valentina_Proiect_Pies.Controllers
{
    public class HomeController : Controller
    {
        private readonly PieContext _context;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PieContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Chat()
        {
            return View();
        }
        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data =
            from order in _context.Orders
            group order by order.OrderDate into dateGroup
            select new OrderGroup()
            {
                OrderDate = dateGroup.Key,
                PieCount = dateGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
