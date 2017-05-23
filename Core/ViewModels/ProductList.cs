using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class ProductList
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Category { get; set; }

    }
}
