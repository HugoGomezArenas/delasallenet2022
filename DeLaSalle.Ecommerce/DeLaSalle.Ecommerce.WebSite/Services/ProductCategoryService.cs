using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.WebSite.Services.Interfaces;
using Newtonsoft.Json;

namespace DeLaSalle.Ecommerce.WebSite.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly string _baseURL = "https://localhost:7222/";
    private readonly string _endpoint = "api/productcategories";
    
    public ProductCategoryService()
    {
        
    }
    
    public async Task<Response<List<ProductCategoryDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<List<ProductCategoryDto>>>(json);
        return response;
    }

    public async Task<Response<ProductCategoryDto>> GetById(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);
        
        return response;
        
    }
}