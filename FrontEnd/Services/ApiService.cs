using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Net.Http.Json;

using FrontEnd.Models;
namespace FrontEnd.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient();
    }
    //Order
    public async Task<List<OrderModel>> GetOrders()
    {
        try
        {
            var apiResponse = await _httpClient.GetStringAsync("http://localhost:5051/api/Order");
            List<OrderModel> data = JsonSerializer.Deserialize<List<OrderModel>>(apiResponse);
            Console.WriteLine(apiResponse);
            return data;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public async Task<bool> PostOrder(OrderModel data)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5051/api/Order", data);
            return response.IsSuccessStatusCode;
        }
        catch (System.Exception)
        {
            return false;
            throw;
        }
    }
    //Products
    public async Task<List<ProductModel>> GetProducts()
    {
        try
        {
            var apiResponse = await _httpClient.GetStringAsync("http://localhost:5051/api/Product");
            var data = JsonSerializer.Deserialize<List<ProductModel>>(apiResponse);
            return data;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task<List<ProductModel>> GetProductsByOrder(int id)
    {
        try
        {
            var apiResponse = await _httpClient.GetStringAsync($"http://localhost:5051/api/Product/GetByOrder?id={id}");
            Console.WriteLine($"data: {apiResponse}");
            var data = JsonSerializer.Deserialize<List<ProductModel>>(apiResponse);
            return data;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task<ProductModel> GetProductById(int id)
    {
        try
        {
            var apiResponse = await _httpClient.GetStringAsync($"http://localhost:5051/api/Product/{id}");
            Console.WriteLine($"data: {apiResponse}");
            var data = JsonSerializer.Deserialize<ProductModel>(apiResponse);
            return data;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public async Task<bool> PostProduct(ProductModel data)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5051/api/Product", data);
            return response.IsSuccessStatusCode;
        }
        catch (System.Exception)
        {
            return false;
            throw;
        }
    }
    public async Task<bool> PutProduct(ProductModel data, int id)
    {
        try
        {
            var url = $"http://localhost:5051/api/Product/{id}";
            var response = await _httpClient.PutAsJsonAsync(url, data);
            return response.IsSuccessStatusCode;
        }
        catch (System.Exception)
        {
            // En caso de excepción, devuelve false
            return false;
            throw;
        }
    }

    public async Task<bool> PostRange(OrderModel order, IEnumerable<ProductModel> products)
    {
        try
        {
            var orderResponse = await _httpClient.PostAsJsonAsync("http://localhost:5051/api/Order", order);
            orderResponse.EnsureSuccessStatusCode();
            var createdOrder = await orderResponse.Content.ReadFromJsonAsync<OrderModel>();
            int orderId = createdOrder.id;
            foreach (var product in products)
            {
                product.idOrderFk = orderId;
            }
            var productResponse = await _httpClient.PostAsJsonAsync("http://localhost:5051/api/Product/Range", products);
            return productResponse.IsSuccessStatusCode;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
}