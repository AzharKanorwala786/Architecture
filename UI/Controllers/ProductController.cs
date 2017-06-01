using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Core.Models;
using Core.ViewModels;
namespace UI.Controllers
{
    public class ProductController : Controller
    {
        HttpClient client;

        string url = "http://localhost:52845/API/Product";

        public ProductController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Product = JsonConvert.DeserializeObject<List<Product>>(responseData);

                return View(Product);
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult Create()
        {
           return PartialView(new ProductCreate());
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductCreate entity)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, entity);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
      
        public async Task<ActionResult> Update(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Product = JsonConvert.DeserializeObject<Product>(responseData);

                return View(Product);
            }
            return View("Error");
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, ProductCreate entity)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, entity);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Product = JsonConvert.DeserializeObject<ProductDetails>(responseData);

                return View(Product);
            }
            return View("Error");
        }

        public async Task<ActionResult> Delete(int id, Product entity)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
    }
}