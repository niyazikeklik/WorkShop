using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkShop.Business.Services.Abstract;
using WorkShop.Core.Concrete;
using WorkShop.Core.Concrete.ViewModel.Request;
using WorkShop.EFCore.Contexts;

namespace WorkShop.Business.Services.Concreate;

public class ProductService : IProductService
{
    private AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsByQuery(ProductQuery query)
    {
        var cat = await _context.Categories

            .Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == query.CategoryId);

        return cat?.Products?.ToList();
    }
}