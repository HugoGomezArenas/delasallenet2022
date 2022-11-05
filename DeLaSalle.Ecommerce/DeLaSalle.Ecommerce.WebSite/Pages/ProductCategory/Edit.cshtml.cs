using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Ecommerce.WebSite.Pages.ProductCategory;

public class Edit : PageModel
{
    [BindProperty]public ProductCategoryDto ProductCategoryDto { get; set; }

    private readonly IProductCategoryService _service;
    

    public Edit(IProductCategoryService service)
    {
        ProductCategoryDto = new ProductCategoryDto();
        _service = service;
    }
    
    public async  Task<ActionResult> OnGet(int? id)
    {
        ProductCategoryDto = new ProductCategoryDto();
        
        if (id.HasValue)
        {
            // Get the information from the service (API)
            var response = await _service.GetById(id.Value);
            ProductCategoryDto = response.Data;
        }

        if (ProductCategoryDto == null)
        {
            return RedirectToPage("/Error");
        }


        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var name = ProductCategoryDto.Name;
        var description = ProductCategoryDto.Description;
        

        return RedirectToPage("./List");
    }


}