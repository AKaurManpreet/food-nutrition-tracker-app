using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FoodNutritionTracker.Pages.Scanner
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<JsonResult> OnGetGetProductDetails(string barcode)
        {
            string url = $"https://world.openfoodfacts.org/api/v0/product/{barcode}.json";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
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
        }

        private ProductDetails? ParseProductDetails(string jsonData)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonData);
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

        private class ProductDetails
        {
            public string ProductName { get; set; } = "Unknown";
            public string Brand { get; set; } = "Unknown";
            public string NutritionGrade { get; set; } = "Unknown";
        }
    }
}