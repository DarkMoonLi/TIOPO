using lab9CSharp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab9CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController
    {
        static HttpClient httpClient = new HttpClient();
        static string url = "http://shop.qatl.ru/";

        // GET: api/<ValuesController>
        [HttpGet]
        public async void GetAllProducts()
        {
            var response = await httpClient.GetAsync(url + "api/products");
            Console.WriteLine(response);
            //return response.Content;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async void DeleteProduct(int id)
        {
            var response = await httpClient.DeleteAsync($"https://localhost:7094/api/users/{id}");
            Console.WriteLine(response);
            //return product;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<Product> AddProduct(Product product)
        {
            var response = await httpClient.PostAsJsonAsync(url + "api/addproduct", JsonSerializer.Serialize(product));
            Product productResponse = await response.Content.ReadFromJsonAsync<Product>();
            return productResponse;
        }

        // POST api/<ValuesController>/5
        [HttpPost("{id}")]
        public async Task<Product> EditProduct(int id,Product product)
        {
            var response = await httpClient.PutAsJsonAsync("https://localhost:7094/api/users/", product);
            Product? productJson = await response.Content.ReadFromJsonAsync<Product>();
            return productJson;
        }
    }
}
