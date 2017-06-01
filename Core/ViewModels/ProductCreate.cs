using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Core.ViewModels
{
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

        //public string CategoryName { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
