using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Core.Concrete.ViewModel;

using WorkShop.Core.Concrete;
using WorkShop.Business.Http.Abstract;

namespace WorkShop.Business.Http.Concreate;

public class CategoryHttp : ICategoryHttp
{
    private HttpClient _httpClient;

    public CategoryHttp()
    {
        _httpClient = new HttpClient();
        //Gerekli konfigarasyonlar ile (headers, auth) oluşturulmuş bir servis de kullanılabilirdi.
        //Solid prensiplerinden bağımlılık enjeksiyonu prensibine aykırı bir davranış.
    }

    public async Task<List<Category>?> GetAllCategories()
    {
        var products = await _httpClient.GetFromJsonAsync<List<Category>>($@"{AppConst.ApiBaseUrl}/Category");
        return products;
    }
}