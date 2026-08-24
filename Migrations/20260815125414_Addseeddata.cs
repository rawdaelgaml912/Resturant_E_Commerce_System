using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurant_Project.Migrations
{
    /// <inheritdoc />
    public partial class Addseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Categories_CategoryCetegoryId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CategoryCetegoryId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "CategoryCetegoryId",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "CetegoryId",
                table: "MenuItems",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "CetegoryId",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Appetizers" },
                    { 2, "Main Courses" },
                    { 3, "Pizza" },
                    { 4, "Burgers" },
                    { 5, "Pasta" },
                    { 6, "Desserts" },
                    { 7, "Drinks" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Crispy chicken wings served with our special sauce.", "Chicken Wings", 180m },
                    { 2, 1, "Crispy mozzarella sticks served with tomato sauce.", "Mozzarella Sticks", 150m },
                    { 3, 1, "Fresh bread with garlic, butter and herbs.", "Garlic Bread", 90m },
                    { 4, 2, "Juicy grilled chicken breast served with rice and vegetables.", "Grilled Chicken", 280m },
                    { 5, 2, "Tender grilled beef steak served with vegetables and fries.", "Beef Steak", 450m },
                    { 6, 2, "Grilled chicken with creamy Alfredo sauce and pasta.", "Chicken Alfredo", 260m },
                    { 7, 3, "Classic pizza with tomato sauce, mozzarella and fresh basil.", "Margherita Pizza", 180m },
                    { 8, 3, "Pizza topped with grilled chicken, mozzarella and vegetables.", "Chicken Pizza", 230m },
                    { 9, 3, "Classic pizza topped with pepperoni and mozzarella cheese.", "Pepperoni Pizza", 250m },
                    { 10, 4, "Juicy beef burger with lettuce, tomato, onion and special sauce.", "Classic Beef Burger", 220m },
                    { 11, 4, "Crispy chicken burger with lettuce, cheese and special sauce.", "Chicken Burger", 190m },
                    { 12, 4, "Beef burger topped with melted cheddar cheese.", "Cheese Burger", 240m },
                    { 13, 5, "Spaghetti pasta with rich beef tomato sauce.", "Spaghetti Bolognese", 210m },
                    { 14, 5, "Fettuccine pasta with creamy Alfredo sauce and parmesan.", "Fettuccine Alfredo", 220m },
                    { 15, 5, "Penne pasta with spicy tomato sauce and herbs.", "Penne Arrabbiata", 180m },
                    { 16, 6, "Rich and moist chocolate cake served with chocolate sauce.", "Chocolate Cake", 130m },
                    { 17, 6, "Creamy cheesecake served with strawberry sauce.", "Cheesecake", 140m },
                    { 18, 6, "Three scoops of your favorite ice cream flavors.", "Ice Cream", 100m },
                    { 19, 7, "Freshly squeezed orange juice.", "Fresh Orange Juice", 80m },
                    { 20, 7, "Chilled soft drink.", "Cola", 50m },
                    { 21, 7, "Fresh mango juice served chilled.", "Mango Juice", 90m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryId",
                table: "MenuItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Categories_CategoryId",
                table: "MenuItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Categories_CategoryId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CategoryId",
                table: "MenuItems");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "MenuItems",
                newName: "CetegoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CetegoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryCetegoryId",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryCetegoryId",
                table: "MenuItems",
                column: "CategoryCetegoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Categories_CategoryCetegoryId",
                table: "MenuItems",
                column: "CategoryCetegoryId",
                principalTable: "Categories",
                principalColumn: "CetegoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
