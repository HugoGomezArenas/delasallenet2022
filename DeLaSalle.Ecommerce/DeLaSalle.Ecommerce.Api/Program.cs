using System.Data.Common;
using Dapper.Contrib.Extensions;
using DeLaSalle.Ecommerce.Api.DataAccess;
using DeLaSalle.Ecommerce.Api.DataAccess.Interfaces;
using DeLaSalle.Ecommerce.Api.Middlewares;
using DeLaSalle.Ecommerce.Api.Repositories;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Services;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSingleton<IProductCategoryRepository,InMemoryProductCategoryRepository>();
builder.Services.AddScoped<IProductCategoryRepository,ProductCategoryRepository>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IDbContext, DbContext>();

SqlMapperExtensions.TableNameMapper = entityType =>
{
    var name = entityType.ToString();
    if (name.Contains("DeLaSalle.Ecommerce.Core.Entities."))
        name = name.Replace("DeLaSalle.Ecommerce.Core.Entities.", "");
    var letters = name.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);
    return new string(letters);
};


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();