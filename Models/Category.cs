using System.ComponentModel.DataAnnotations;

namespace Resturant_Project.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }    

        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();    
    }
}
