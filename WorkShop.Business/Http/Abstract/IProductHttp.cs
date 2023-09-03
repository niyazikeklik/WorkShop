using WorkShop.Core.Concrete;
using WorkShop.Core.Concrete.ViewModel.Request;

namespace WorkShop.Business.Http.Abstract;

public interface IProductHttp
{
    Task<List<Product>> GetProductsByQuery(ProductQuery query);
}