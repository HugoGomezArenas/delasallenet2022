using Dapper;
using Dapper.Contrib.Extensions;
using DeLaSalle.Ecommerce.Api.DataAccess.Interfaces;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{

    private readonly IDbContext _dbContext;
    
    public ProductCategoryRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductCategory> SaveAsync(ProductCategory category)
    {
        category.Id = await _dbContext.Connection.InsertAsync(category);

        return category;
    }

    public async Task<ProductCategory> UpdateAsync(ProductCategory category)
    {
        await _dbContext.Connection.UpdateAsync(category);
        return category;
    }

    public async Task<List<ProductCategory>> GetAllAsync()
    {
        const string sql = "SELECT *  FROM ProductCategory WHERE IsDeleted = 0";
        var categories = await _dbContext.Connection.QueryAsync<ProductCategory>(sql);
        return categories.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await GetById(id);

        if (category == null)
            return false;

        category.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(category);
    }

    public async Task<ProductCategory> GetById(int id)
    {
        var category = await _dbContext.Connection.GetAsync<ProductCategory>(id);

        if (category == null)
            return null;

        return category.IsDeleted == true ? null : category;
    }

    public async Task<ProductCategory> GetByName(string name, int id = 0)
    {
        var sql = $"SELECT *  FROM ProductCategory WHERE Name = '{name}' AND Id <> {id} ";
        var categories = 
            await _dbContext.Connection.QueryAsync<ProductCategory>(sql);
        return categories.ToList().FirstOrDefault();
    }
    
}