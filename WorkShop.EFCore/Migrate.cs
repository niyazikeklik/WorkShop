using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkShop.EFCore.Contexts;

namespace WorkShop.EFCore;

public class Migrate
{
    private readonly Contexts.AppDbContext _context;

    public Migrate(Contexts.AppDbContext context)
    {
        this._context = context;
    }

    public async void MigrateDatabase()
    {
        await _context.Database.EnsureCreatedAsync();

        if (!_context.Categories.Any())
        {
            //Mock Data

            var categories = new List<Core.Concrete.Category>
            {
                new()
                {
                    Name = "Kategori 1"
                },
                new Core.Concrete.Category
                {
                    Name = "Kategori 2"
                },
                new Core.Concrete.Category
                {
                    Name = "Kategori 3"
                },
                new Core.Concrete.Category
                {
                    Name = "Kategori 4"
                }
            };

            await _context.Categories.AddRangeAsync(categories);
            await _context.SaveChangesAsync();
        }

        if (!_context.Products.Any())
        {
            var categoryList = await _context.Categories.ToListAsync();
            int count = 0;
            for (int i = 0; i < categoryList.Count; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    _context.Products.Add(new()
                    {
                        Name = "Product " + ++count,
                        Category = categoryList[i],
                        Price = (i + 1) * j * 10,
                    });
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}