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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl;

        public IndexModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _apiUrl = configuration["OpenFoodFactsApi:Url"] ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetProductDetailsAsync(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                return new JsonResult(new { success = false, message = "Barcode is required." });
            }

            string url = $"{_apiUrl}/api/v2/product/{barcode}";

            try
            {
                using var httpClient = _httpClientFactory.CreateClient();
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    var productDetails = ParseProductDetails(jsonData);

                    if (productDetails != null)
                    {
                        return new JsonResult(new
                        {
                            success = true,
                            productName = productDetails.ProductName,
                            brand = productDetails.Brand,
                            nutritionGrade = productDetails.NutritionGrade
                        });
                    }
                }
                return new JsonResult(new { success = false, message = "Product not found." });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        private ProductDetails? ParseProductDetails(string jsonData)
        {
            try
            {
                var jsonObject = JObject.Parse(jsonData);
                var product = jsonObject["product"] as JObject;

                if (product == null)
                    return null;

                return new ProductDetails
                {
                    ProductName = product["product_name"]?.ToString() ?? "Unknown",
                    Brand = product["brands"]?.ToString() ?? "Unknown",
                    NutritionGrade = product["nutrition_grade_fr"]?.ToString() ?? "Unknown"
                };
            }
            catch
            {
                return null;
            }
        }

        private class ProductDetails
        {
            public string ProductName { get; init; } = "Unknown";
            public string Brand { get; init; } = "Unknown";
            public string NutritionGrade { get; init; } = "Unknown";
        }
    }
}
