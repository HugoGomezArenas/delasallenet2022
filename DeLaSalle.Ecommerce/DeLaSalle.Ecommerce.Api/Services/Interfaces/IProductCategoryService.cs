using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Services.Interfaces;

public interface IProductCategoryService
{
    Task<bool> ProductCategoryExist(int id);
    Task<ProductCategoryDto> SaveAsync(ProductCategoryDto category);
    Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto category);
    Task<List<ProductCategoryDto>> GetAllAsync();
    Task<bool> DeleteAsync(int id);
    Task<ProductCategoryDto> GetById(int id);
    Task<bool> ExistByName(string name, int id = 0);
}
