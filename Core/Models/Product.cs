using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Product Name Is Required")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
