using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NemoStore.Core.Entities;
using NemoStore.Core.IRepository;
using NemoStore.Web.Models;

namespace NemoStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Customer> _customer;
        public HomeController(IRepository<Customer> customer)
        {
            _customer = customer;
        }

        public IActionResult Index()
        {
            var ll = _customer.Get(con => 1 == 1).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
