using System.ComponentModel.DataAnnotations;

namespace newmachinetest.Models
{
    public class Product
    {
        internal object productss;

        [Key]
        public int ProductId { get; set; }


        [Required]
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}

