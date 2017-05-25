using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Core.ViewModels;
using Core.Models;
using BusinessLogic.Interfaces;
using System.Web.Http.Description;

namespace API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductBL _objProduct;
        private readonly IProdCategoryBL _objProductCategory;

        public ProductController(IProductBL products, IProdCategoryBL prodCategory)
        {
            _objProduct = products;
            _objProductCategory = prodCategory;
        }

        [HttpGet]
        public IEnumerable<Product> GetProduct()
        {
            return _objProduct.GetAllProducts();
        }
        [HttpGet]
        public IEnumerable<Product> GetProduct(int id)
        {
            return _objProduct.GetProductsByCategoryId(id);
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult Create(int id, ProductCreate entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
               
            if (id != entity.Id)
            {
                return BadRequest();
            }

            _objProduct.ProductCreate(id);

            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
