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
        public IEnumerable<Product> GetAllProduct()
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
        public IHttpActionResult CreateProduct(ProductCreate entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                entity.Categories = _objProductCategory.GetAllCategory();
            }

            _objProduct.AddProduct(entity);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        public IHttpActionResult UpdateProduct(int Id,ProductCreate entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (Id != entity.Id)
            {
                return BadRequest();
            }
            else
            {
                entity.Categories = _objProductCategory.GetAllCategory();
            }
            _objProduct.UpdateProduct(entity);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int Id)
        {
            Product prods = _objProduct.GetProductById(Id);

            if(prods == null)
            {
                return NotFound();
            }
            else
            {
                _objProduct.DeleteProduct(Id);
            }

            return Ok(prods);
        }
    }
}
