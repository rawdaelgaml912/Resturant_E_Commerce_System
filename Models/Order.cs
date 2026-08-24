namespace Resturant_Project.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public ICollection<OrderItem>OrderItems { get; set; } = new List<OrderItem>();
        public Payment Payment { get; set; }





    }
}
