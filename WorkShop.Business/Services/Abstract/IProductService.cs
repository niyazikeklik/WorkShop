using WorkShop.Core.Concrete;
using WorkShop.Core.Concrete.ViewModel.Request;

namespace WorkShop.Business.Services.Abstract;

public interface IProductService
{
    Task<List<Product>> GetProductsByQuery(ProductQuery query);
}