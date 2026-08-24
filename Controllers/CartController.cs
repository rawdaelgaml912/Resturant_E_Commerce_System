using Microsoft.AspNetCore.Mvc;
using Restaurant_Project.Models;
using Resturant_Project.Data;
using Resturant_Project.Models;

public class CartController : Controller
{
    ApplicationDbContext dbcontext = new ApplicationDbContext();

    public IActionResult Add(int id)
    {
        var menuItem = dbcontext.MenuItems.Find(id);

        if (menuItem == null)
        {
            return NotFound();
        }

        var cart = HttpContext.Session
            .GetObject<List<CartItem>>("Cart");

        if (cart == null)
        {
            cart = new List<CartItem>();
        }

        var existingItem = cart
            .FirstOrDefault(x => x.MenuItemId == id);

        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            cart.Add(new CartItem
            {
                MenuItemId = menuItem.MenuItemId,
                Name = menuItem.Name,
                Price = menuItem.Price,
                Quantity = 1
            });
        }

        HttpContext.Session.SetObject("Cart", cart);

        return RedirectToAction("Index");
    }

    public IActionResult Index()
    {

        var cart = HttpContext.Session
            .GetObject<List<CartItem>>("Cart");

        if (cart == null)
        {
            cart = new List<CartItem>();
        }

        return View(cart);
    }
    public IActionResult Remove(int id)
    {
        var cart = HttpContext.Session
            .GetObject<List<CartItem>>("Cart");

        if (cart != null)
        {
            var item = cart.FirstOrDefault(x => x.MenuItemId == id);

            if (item != null)
            {
                cart.Remove(item);
            }

            HttpContext.Session.SetObject("Cart", cart);
        }

        return RedirectToAction("Index");
    }

}
