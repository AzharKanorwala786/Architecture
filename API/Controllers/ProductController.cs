using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.ViewModels;
using Core.Models;
using BusinessLogic.Interfaces;

namespace API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductBL _objProduct;
        private readonly IProdCategoryBL _objProductCategory;

        public ProductController(IProductBL obj, IProdCategoryBL prodCategory)
        {
            _objProduct = obj;
            _objProductCategory = prodCategory;
        }
        public IEnumerable<Product> GetProduct()
        {
            return _objProduct.GetAllProducts();
        }

        public IEnumerable<Product> GetProduct(int id)
        {
            return _objProduct.GetProductsByCategoryId(id);
        }


    }
}
