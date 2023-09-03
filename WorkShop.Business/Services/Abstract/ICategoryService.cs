using WorkShop.Core.Concrete;
using WorkShop.Core.Concrete.ViewModel;

namespace WorkShop.Business.Services.Abstract;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategories();
}