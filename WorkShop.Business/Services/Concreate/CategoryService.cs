using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkShop.Business.Services.Abstract;
using WorkShop.Core.Concrete;
using WorkShop.Core.Concrete.ViewModel;
using WorkShop.EFCore.Contexts;

namespace WorkShop.Business.Services.Concreate;

public class CategoryService : ICategoryService
{
    private AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllCategories()
    {
        var result = await _context.Categories.ToListAsync();
        return result;
    }
}