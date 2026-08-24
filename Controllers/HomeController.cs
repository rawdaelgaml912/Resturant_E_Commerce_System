using Microsoft.AspNetCore.Mvc;
using Resturant_Project.Data;
using Resturant_Project.Models;
using System.Diagnostics;

namespace Resturant_Project.Controllers
{
     
    public class HomeController : Controller
    {
        ApplicationDbContext dbcontext = new ApplicationDbContext();
        public IActionResult Index()
        {
            var MenuItems = dbcontext.MenuItems.ToList();

            return View(model: MenuItems);
        }

        public IActionResult Details(int id)
        {
            var menuItem = dbcontext.MenuItems.Find(id);

            if (menuItem == null)
            {
                return RedirectToAction("NotFoundPage");
            }
            return View(menuItem);
        }

        public IActionResult NotFoundPage()
        {
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
