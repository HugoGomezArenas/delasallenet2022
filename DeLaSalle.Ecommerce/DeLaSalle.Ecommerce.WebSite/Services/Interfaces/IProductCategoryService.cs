using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;

namespace DeLaSalle.Ecommerce.WebSite.Services.Interfaces;

public interface IProductCategoryService
{
    Task<Response<List<ProductCategoryDto>>> GetAllAsync();
    Task<Response<ProductCategoryDto>> GetById(int id);
    Task<Response<ProductCategoryDto>> SaveAsync(ProductCategoryDto productCategory);
    Task<Response<ProductCategoryDto>> UpdateAsync(ProductCategoryDto productCategory);
    Task<Response<bool>> DeleteAsync(int id);
}