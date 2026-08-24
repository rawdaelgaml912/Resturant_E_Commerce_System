using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resturant_Project.Models;

namespace Resturant_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = .; Database= Restaurant_Project;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // Categories Seed Data
            // =========================

            modelBuilder.Entity<Category>().HasData(

                new Category
                {
                    CategoryId = 1,
                    Name = "Appetizers"
                },

                new Category
                {
                    CategoryId = 2,
                    Name = "Main Courses"
                },

                new Category
                {
                    CategoryId = 3,
                    Name = "Pizza"
                },

                new Category
                {
                    CategoryId = 4,
                    Name = "Burgers"
                },

                new Category
                {
                    CategoryId = 5,
                    Name = "Pasta"
                },

                new Category
                {
                    CategoryId = 6,
                    Name = "Desserts"
                },

                new Category
                {
                    CategoryId = 7,
                    Name = "Drinks"
                }
            );


            // =========================
            // Menu Items Seed Data
            // =========================

            modelBuilder.Entity<MenuItem>().HasData(

                new MenuItem
                {
                    MenuItemId = 1,
                    Name = "Chicken Wings",
                    Description = "Crispy chicken wings served with our special sauce.",
                    Price = 180,
                    ImageUrl = "/img/chicken wings food.jfif",
                    CategoryId = 1
                },

                new MenuItem
                {
                    MenuItemId = 2,
                    Name = "Mozzarella Sticks",
                    Description = "Crispy mozzarella sticks served with tomato sauce.",
                    Price = 150,
                    ImageUrl = "/img/mozzarella sticks.jfif",
                    CategoryId = 1
                },

                new MenuItem
                {
                    MenuItemId = 3,
                    Name = "Garlic Bread",
                    Description = "Fresh bread with garlic, butter and herbs.",
                    Price = 90,
                    ImageUrl = "/img/garlic bread.jfif",
                    CategoryId = 1
                },

                new MenuItem
                {
                    MenuItemId = 4,
                    Name = "Grilled Chicken",
                    Description = "Juicy grilled chicken breast served with rice and vegetables.",
                    Price = 280,
                    ImageUrl = "/img/grilled chicken.jfif",
                    CategoryId = 2
                },

                new MenuItem
                {
                    MenuItemId = 5,
                    Name = "Beef Steak",
                    Description = "Tender grilled beef steak served with vegetables and fries.",
                    Price = 450,
                    ImageUrl = "/img/beef steak fries.jfif",
                    CategoryId = 2
                },

                new MenuItem
                {
                    MenuItemId = 6,
                    Name = "Chicken Alfredo",
                    Description = "Grilled chicken with creamy Alfredo sauce and pasta.",
                    Price = 260,
                    ImageUrl = "/img/chicken alfredo pasta.jfif",
                    CategoryId = 2
                },

                new MenuItem
                {
                    MenuItemId = 7,
                    Name = "Margherita Pizza",
                    Description = "Classic pizza with tomato sauce, mozzarella and fresh basil.",
                    Price = 180,
                    ImageUrl = "/img/margherita pizza.jfif",
                    CategoryId = 3
                },

                new MenuItem
                {
                    MenuItemId = 8,
                    Name = "Chicken Pizza",
                    Description = "Pizza topped with grilled chicken, mozzarella and vegetables.",
                    Price = 230,
                    ImageUrl = "/img/chicken pizza.jfif",
                    CategoryId = 3
                },

                new MenuItem
                {
                    MenuItemId = 9,
                    Name = "Pepperoni Pizza",
                    Description = "Classic pizza topped with pepperoni and mozzarella cheese.",
                    Price = 250,
                    ImageUrl = "/img/pepperoni pizza.jfif",
                    CategoryId = 3
                },

                new MenuItem
                {
                    MenuItemId = 10,
                    Name = "Classic Beef Burger",
                    Description = "Juicy beef burger with lettuce, tomato, onion and special sauce.",
                    Price = 220,
                    ImageUrl = "/img/classic beef burger.jfif",
                    CategoryId = 4
                },

                new MenuItem
                {
                    MenuItemId = 11,
                    Name = "Chicken Burger",
                    Description = "Crispy chicken burger with lettuce, cheese and special sauce.",
                    Price = 190,
                    ImageUrl = "/img/crispy chicken burger.jfif",
                    CategoryId = 4
                },

                new MenuItem
                {
                    MenuItemId = 12,
                    Name = "Cheese Burger",
                    Description = "Beef burger topped with melted cheddar cheese.",
                    Price = 240,
                    ImageUrl = "/img/cheeseburger.jfif",
                    CategoryId = 4
                },

                new MenuItem
                {
                    MenuItemId = 13,
                    Name = "Spaghetti Bolognese",
                    Description = "Spaghetti pasta with rich beef tomato sauce.",
                    Price = 210,
                    ImageUrl = "/img/spaghetti bolognese.jfif",
                    CategoryId = 5
                },

                new MenuItem
                {
                    MenuItemId = 14,
                    Name = "Fettuccine Alfredo",
                    Description = "Fettuccine pasta with creamy Alfredo sauce and parmesan.",
                    Price = 220,
                    ImageUrl = "/img/fettuccine alfredo.jfif",
                    CategoryId = 5
                },

                new MenuItem
                {
                    MenuItemId = 15,
                    Name = "Penne Arrabbiata",
                    Description = "Penne pasta with spicy tomato sauce and herbs.",
                    Price = 180,
                    ImageUrl = "/img/penne arrabbiata.jfif",
                    CategoryId = 5
                },

                new MenuItem
                {
                    MenuItemId = 16,
                    Name = "Chocolate Cake",
                    Description = "Rich and moist chocolate cake served with chocolate sauce.",
                    Price = 130,
                    ImageUrl = "/img/chocolate cake.jfif",
                    CategoryId = 6
                },

                new MenuItem
                {
                    MenuItemId = 17,
                    Name = "Cheesecake",
                    Description = "Creamy cheesecake served with strawberry sauce.",
                    Price = 140,
                    ImageUrl = "/img/cheesecake strawberry.jfif",
                    CategoryId = 6
                },

                new MenuItem
                {
                    MenuItemId = 18,
                    Name = "Ice Cream",
                    Description = "Three scoops of your favorite ice cream flavors.",
                    Price = 100,
                    ImageUrl = "/img/ice cream.jfif",
                    CategoryId = 6
                },

                new MenuItem
                {
                    MenuItemId = 19,
                    Name = "Fresh Orange Juice",
                    Description = "Freshly squeezed orange juice.",
                    Price = 80,
                    ImageUrl = "/img/fresh orange juice.jfif",
                    CategoryId = 7
                },

                new MenuItem
                {
                    MenuItemId = 20,
                    Name = "Cola",
                    Description = "Chilled soft drink.",
                    Price = 50,
                    ImageUrl = "/img/cola glass ice.jfif",
                    CategoryId = 7
                },

                new MenuItem
                {
                    MenuItemId = 21,
                    Name = "Mango Juice",
                    Description = "Fresh mango juice served chilled.",
                    Price = 90,
                    ImageUrl = "/img/fresh mango juice glass.jfif",
                    CategoryId = 7
                }
            );
        }
    }
}