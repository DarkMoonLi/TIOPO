using CheckClocks.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckClocks.Controllers
{
    public class ProductController
    {
        static HttpClient httpClient = new HttpClient();
        static string url = "http://shop.qatl.ru/";

        public async Task<HttpResponseMessage> GetAllProducts()
        {
            var response = await httpClient.GetAsync(url + "api/products");
            return response;
        }

        public async Task<HttpResponseMessage> DeleteProduct(int id)
        {
            var response = await httpClient.DeleteAsync(url + $"api/users/{id}");
            return response;
        }

        public async Task<HttpResponseMessage> AddProduct(Product product)
        {
            var response = await httpClient.PostAsJsonAsync(url + "api/addproduct", JsonSerializer.Serialize(product));
            return response;
        }

        public async Task<HttpResponseMessage> EditProduct(int id, Product product)
        {
            var response = await httpClient.PutAsJsonAsync(url + "api/editproduct", product);
            return response;
        }
    }
}
