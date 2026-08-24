using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant_Project.Data;
using Resturant_Project.Models;

namespace Restaurant_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        public IActionResult Index()
        {
            var categories = dbContext.Categories.ToList();

            return View(model: categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = dbContext.Categories.Find(id);

            if (category == null)
            {
                return View("NotFoundPage");
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            dbContext.Categories.Update(category);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = dbContext.Categories.Find(id);

            if (category == null)
            {
                return View("NotFounPage");
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = dbContext.Categories.Find(id);

            if (category == null)
            {
                return View("NotFounPage");
            }

            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}