using Microsoft.Extensions.DependencyInjection;
using WorkShop.EFCore.Contexts;
using WorkShop.EFCore;
using Microsoft.EntityFrameworkCore;
using WorkShop.Business.Services.Abstract;
using WorkShop.Business.Services.Concreate;
using WorkShop.Business.Http.Abstract;
using WorkShop.Business.Http.Concreate;

namespace WorkShop.API;

public class RegisterService
{
    public static void RegisterAPI(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
    }

    public static void RegisterWebApp(IServiceCollection services)
    {
        services.AddScoped<IProductHttp, ProductHttp>();
        services.AddScoped<ICategoryHttp, CategoryHttp>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}