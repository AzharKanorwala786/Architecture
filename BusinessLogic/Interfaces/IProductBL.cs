using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Models;
using Core.ViewModels;

namespace BusinessLogic.Interfaces
{
   public interface IProductBL : IGenericBL<Product>
    {
        //Calling ViewModels
        void AddProduct(ProductCreate collection);

        //void AddProduct(Product collection);
        void UpdateProduct(ProductCreate collection);

        void DeleteProduct(int Id);

        Product GetProductById(int Id);

        ProductCreate ProductCreate(int id);

        ProductDetails GetProductDetails(int id);

        ProductList DisplayProductDetails(int CategoryId = 0);

        IEnumerable<Product> GetAllProducts();

        IEnumerable<Product> GetProductsByCategoryId(int CategoryId);

    }
}
