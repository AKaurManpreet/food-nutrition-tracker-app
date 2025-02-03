using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace FoodNutritionTracker.Pages.Scanner
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public IndexModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiUrl = configuration["OpenFoodFactsApi:Url"];
        }

        public void OnGet()
        {
        }

        public async Task<JsonResult> OnGetProductDetailsAsync(string barcode)
        {
            string url = $"{_apiUrl}/{barcode}.json";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    var productDetails = ParseProductDetails(jsonData);

                    if (productDetails != null)
                    {
                        return new JsonResult(new
                        {
                            success = true,
                            productName = productDetails.ProductName ?? "Unknown",
                            brand = productDetails.Brand ?? "Unknown",
                            nutritionGrade = productDetails.NutritionGrade ?? "Unknown"
                        });
                    }
                }
                return new JsonResult(new { success = false, message = "Product not found." });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }

        private ProductDetails? ParseProductDetails(string jsonData)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonData);
                if (jsonObject["status"]?.ToObject<int>() != 1)
                    return null;

                JObject? product = (JObject?)jsonObject["product"];
                if (product == null)
                    return null;

                return new ProductDetails
                {
                    ProductName = (string?)product["product_name"] ?? "Unknown",
                    Brand = (string?)product["brands"] ?? "Unknown",
                    NutritionGrade = (string?)product["nutrition_grade_fr"] ?? "Unknown"
                };
            }
            catch
            {
                return null;
            }
        }

        private record ProductDetails(string ProductName = "Unknown", string Brand = "Unknown", string NutritionGrade = "Unknown");
    }
}