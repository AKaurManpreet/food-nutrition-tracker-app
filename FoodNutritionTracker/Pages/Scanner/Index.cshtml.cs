using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodNutritionTracker.Pages.Scanner
{
    public class ScannerModel : PageModel
    {
        public void OnGet()
        {
            // You can leave this empty or handle any preconditions for the frontend
        }

        // This is a placeholder Post method if you need one, but as you're handling all in frontend, it won't be used.
        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public IActionResult OnPostUploadImage()
        {
            // Since frontend will handle image and barcode, we don't need to do anything here.
            string value = "Image uploaded successfully.";

            // Returning a simple success response
            return new JsonResult(new { success = true, message = value });
        }
    }
}
