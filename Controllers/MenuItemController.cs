using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant_Project.Data;
using Resturant_Project.Models;
using System.ComponentModel.Design;

namespace Restaurant_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MenuItemController : Controller
    {
        ApplicationDbContext dbcontext = new ApplicationDbContext();

        //public IActionResult Index()
        //{

        //    var menuItems = dbcontext.MenuItems.ToList();


        //    return View(menuItems);
        //}



        public IActionResult Index()
        {

            var menuItems = dbcontext.MenuItems.Include(m => m.Category).ToList();


            return View(menuItems);
        }

        // Get
        //public IActionResult Create()
        //{
        //    return View();
        //}

        public IActionResult Create()
        {
            var categories = dbcontext.Categories.ToList();

            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                return View(menuItem);
            }

            dbcontext.MenuItems.Add(menuItem);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }

        //public IActionResult Edit (int id)
        //{

        //    var menuItem = dbcontext.MenuItems.Find(id);
        //     if(menuItem == null)
        //    {
        //        return View("NotFoundPage");

        //    }
        //        return View(menuItem);

        //}


        public IActionResult Edit(int id)
        {

            var menuItem = dbcontext.MenuItems.Find(id);
            if (menuItem == null)
            {
                return View("NotFoundPage");

            }

            var categories = dbcontext.Categories.ToList();
            ViewBag.Categories = categories;
            return View(menuItem);

        }

        [HttpPost]
        public IActionResult Edit(MenuItem menuItem)
        {

            if (!ModelState.IsValid)
            {
                return View(menuItem);
            }

            dbcontext.MenuItems.Update(menuItem);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var menuItem = dbcontext.MenuItems.Find(id);

            if (menuItem == null)
            {
                return View("NotFoundPage");
            }

            return View(menuItem);

        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var menuItem = dbcontext.MenuItems.Find(id);

            if (menuItem == null)
            {
                return View("NotFoundPage");
            }

            dbcontext.MenuItems.Remove(menuItem);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");


        }
    }
}