namespace Core.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core.Models;

    public class ProductCreate
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Product Name Is Required")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
