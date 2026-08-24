using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Project.Models;
using Restaurant_Project.Services;
using Resturant_Project.Data;
using Resturant_Project.Models;

namespace Restaurant_Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext dbcontext;
        private readonly PaymobService paymobService;
        private readonly IConfiguration configuration;

        public OrderController(
            ApplicationDbContext dbcontext,
            PaymobService paymobService,
            IConfiguration configuration)
        {
            this.dbcontext = dbcontext;
            this.paymobService = paymobService;
            this.configuration = configuration;
        }

        // Checkout
        [Authorize]
        public IActionResult Checkout()
        {
            var cart = HttpContext.Session
                .GetObject<List<CartItem>>("Cart");

            if (cart == null || cart.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            return View(cart);
        }

        // Place Order
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(
            string FullName,
            string Phone,
            string Address,
            PaymentMethod PaymentMethod)
        {
            var cart = HttpContext.Session
                .GetObject<List<CartItem>>("Cart");

            if (cart == null || cart.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            // Create Order
            var order = new Order
            {
                OrderDate = DateTime.Now,

                TotalPrice = cart.Sum(
                    x => x.Price * x.Quantity
                ),

                Status = "Pending"
            };

            // Create Order Items
            foreach (var item in cart)
            {
                order.OrderItems.Add(
                    new OrderItem
                    {
                        MenuItemId = item.MenuItemId,
                        Quantity = item.Quantity,
                        UnitPrice = item.Price
                    }
                );
            }

            // Create Payment
            var payment = new Payment
            {
                Amount = order.TotalPrice,

                PaymentMethod = PaymentMethod,

                PaymentDate = DateTime.Now,

                PaymentStatus = PaymentStatus.Pending,

                Order = order
            };

            // Save Order + Payment
            dbcontext.Orders.Add(order);
            dbcontext.Payments.Add(payment);

            dbcontext.SaveChanges();

            // Cash Payment
            if (PaymentMethod == PaymentMethod.Cash)
            {
                HttpContext.Session.Remove("Cart");

                return RedirectToAction("Success");
            }

            // Card Payment
            if (PaymentMethod == PaymentMethod.Card)
            {
                try
                {
                    var clientSecret =
                        await paymobService.CreatePaymentIntention(
                            order.TotalPrice,
                            FullName,
                            Phone,
                            Address
                        );

                    var publicKey =
                        configuration["Paymob:PublicKey"];

                    HttpContext.Session.Remove("Cart");

                    ViewBag.ClientSecret = clientSecret;

                    ViewBag.PublicKey = publicKey;

                    return View("Payment", order);
                }
                catch (Exception ex)
                {
                    payment.PaymentStatus =
                        PaymentStatus.Pending;

                    dbcontext.SaveChanges();

                    return Content(
                        "Paymob Error: " + ex.Message
                    );
                }
            }

            return RedirectToAction("Success");
        }

        // Success
        [Authorize]
        public IActionResult Success()
        {
            var order = dbcontext.Orders
                .OrderByDescending(x => x.OrderId)
                .FirstOrDefault();

            if (order == null)
            {
                return NotFound();
            }

            var payment = dbcontext.Payments
                .OrderByDescending(x => x.PaymentId)
                .FirstOrDefault(
                    x => x.OrderId == order.OrderId
                );

            ViewBag.PaymentStatus =
                payment?.PaymentStatus;

            ViewBag.PaymentMethod =
                payment?.PaymentMethod;

            return View(order);
        }
    }
}