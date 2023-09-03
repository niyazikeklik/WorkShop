using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using WorkShop.Business.Http.Abstract;
using WorkShop.Core.Concrete;
using WorkShop.Core.Concrete.ViewModel.Request;

namespace WorkShop.Business.Http.Concreate;

public class ProductHttp : IProductHttp
{

    private HttpClient _httpClient;

    public ProductHttp()
    {
        _httpClient = new HttpClient();
        //Gerekli konfigarasyonlar ile (headers, auth) oluşturulmuş bir servis de kullanılabilirdi.
        //Solid prensiplerinden bağımlılık enjeksiyonu prensibine aykırı bir davranış.
    }

    public async Task<List<Product>?> GetProductsByQuery(ProductQuery query)
    {
        var products = await _httpClient.GetFromJsonAsync<List<Product>>($@"{AppConst.ApiBaseUrl}/Product?CategoryId={query.CategoryId}");
        return products;
    }
}