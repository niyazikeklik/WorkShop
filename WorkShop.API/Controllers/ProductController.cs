using Microsoft.AspNetCore.Mvc;

using WorkShop.Business.Http;
using WorkShop.Business.Services.Abstract;
using WorkShop.Core.Concrete;
using WorkShop.Core.Concrete.ViewModel.Request;

namespace WorkShop.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<List<Product>> GetProductsByQuery([FromQuery] ProductQuery query)
    {
        var result = await _productService.GetProductsByQuery(query) ?? new List<Product>();
        return result;
    }
}