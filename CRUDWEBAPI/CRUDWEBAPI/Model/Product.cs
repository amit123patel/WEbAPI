using System.ComponentModel.DataAnnotations;

namespace CRUDWEBAPI.Model
{
    
        public class Product
        {
            [Key]
            public int ProductId { get; set; }
            public string Name { get; set; } = string.Empty;

            public int Quantity { get; set; }

            public double Price { get; set; }

        }
    
}
