using WorkShop.Core.Concrete;
using WorkShop.Core.Concrete.ViewModel;

namespace WorkShop.Business.Http.Abstract;

public interface ICategoryHttp
{
    Task<List<Category>?> GetAllCategories();
}