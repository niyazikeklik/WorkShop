using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using WorkShop.Business.Http.Abstract;
using WorkShop.Business.Services.Abstract;
using WorkShop.Core.Concrete;
using WorkShop.Core.Concrete.ViewModel.Request;
using WorkShop.Core.Concrete.ViewModel.Response;

namespace WorkShop.WebMvc.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryHttp _categoyHttp;
    private readonly IProductHttp _productHttp;
    private readonly IMapper _mapper;

    public HomeController(IProductHttp productHttp, ICategoryHttp categoyHttp, IMapper mapper)
    {
        _productHttp = productHttp;
        _categoyHttp = categoyHttp;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _categoyHttp.GetAllCategories();

        var result = _mapper.Map<List<CategoryDto>>(data);

        return View(result);
    }

    public async Task<IActionResult> Product(ProductQuery query)
    {
        var data = await _productHttp.GetProductsByQuery(query);

        var result = _mapper.Map<List<ProductDto>>(data);

        return PartialView("Partials/ProductPartial", result);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}