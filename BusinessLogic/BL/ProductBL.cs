using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using BusinessLogic.Interfaces;
using Core.Interfaces;
using Core.ViewModels;
using BusinessLogic.Mapping;

namespace BusinessLogic.BL
{
    public class ProductBL : GenericBL<Product>, IProductBL
    {
        public ProductBL(IUOW UnitOfWork) : base(UnitOfWork)
        {
        }

        public void AddProduct(ProductCreate collection)
        {
            Product prods = MapViewModels.MapObject<ProductCreate, Product>(collection);
            prods.CategoryId = collection.CategoryId;
            base.Insert(prods);
            base.SaveChanges();
        }

        public void UpdateProduct(ProductCreate collection)
        {
            Product prods = MapViewModels.MapObject<ProductCreate, Product>(collection);
            prods.CategoryId = collection.CategoryId;
            base.Update(prods);
            base.SaveChanges();
        }

        public void DeleteProduct(int Id)
        {
            base.Delete<int>(Id);
            base.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return base.GetAllProd();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int CategoryId)
        {
            return base.GetWhere(p => p.CategoryId == CategoryId).ToList();
        }

        public ProductList DisplayProductDetails(int CategoryId = 0)
        {
            throw new NotImplementedException();
        }

        public ProductDetails GetProductDetails(int id)
        {
            throw new NotImplementedException();
        }

        public ProductCreate ProductCreate(int id)
        {
            throw new NotImplementedException();
        }
    }
}
