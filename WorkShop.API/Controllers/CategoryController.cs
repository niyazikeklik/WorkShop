using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkShop.Core.Concrete.ViewModel;
using WorkShop.Core.Concrete;
using WorkShop.Business.Services.Abstract;

namespace WorkShop.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<List<Category>> GetAllCategories()
    {
        var result = await _categoryService.GetAllCategories() ?? new List<Category>();
        return result;
    }
}