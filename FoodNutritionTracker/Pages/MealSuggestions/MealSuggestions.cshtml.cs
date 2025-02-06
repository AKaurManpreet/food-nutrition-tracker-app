using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodNutritionTracker.Pages
{
    public class MealSuggestionModel : PageModel
    {
        [BindProperty]
        public int DailyCalories { get; set; }

        public MealPlan? MealPlan { get; private set; }

        private static readonly List<Meal> MealDatabase = new List<Meal>
        {
            new Meal { Name = "Oatmeal with Berries", Description = "Hearty oatmeal topped with mixed berries", Calories = 300, Type = MealType.Breakfast },
            new Meal { Name = "Scrambled Eggs with Toast", Description = "Fluffy scrambled eggs with whole grain toast", Calories = 400, Type = MealType.Breakfast },
            new Meal { Name = "Greek Yogurt Parfait", Description = "Greek yogurt layered with granola and fruit", Calories = 350, Type = MealType.Breakfast },
            new Meal { Name = "Grilled Chicken Salad", Description = "Mixed greens with grilled chicken and vinaigrette", Calories = 450, Type = MealType.Lunch },
            new Meal { Name = "Vegetable Soup with Whole Grain Bread", Description = "Hearty vegetable soup served with a slice of whole grain bread", Calories = 350, Type = MealType.Lunch },
            new Meal { Name = "Turkey and Avocado Sandwich", Description = "Turkey breast with avocado on whole wheat bread", Calories = 500, Type = MealType.Lunch },
            new Meal { Name = "Baked Salmon with Roasted Vegetables", Description = "Oven-baked salmon fillet with a side of roasted seasonal vegetables", Calories = 550, Type = MealType.Dinner },
            new Meal { Name = "Vegetarian Stir-Fry", Description = "Tofu and mixed vegetables stir-fried in a light sauce, served over brown rice", Calories = 450, Type = MealType.Dinner },
            new Meal { Name = "Lean Beef Steak with Sweet Potato", Description = "Grilled lean beef steak served with a baked sweet potato", Calories = 600, Type = MealType.Dinner }
        };

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MealPlan = GenerateMealPlan(DailyCalories);
            return Page();
        }

        private MealPlan GenerateMealPlan(int dailyCalories)
        {
            int breakfastCalories = (int)(dailyCalories * 0.25);
            int lunchCalories = (int)(dailyCalories * 0.35);
            int dinnerCalories = (int)(dailyCalories * 0.40);

            var breakfast = GetClosestMeal(MealType.Breakfast, breakfastCalories);
            var lunch = GetClosestMeal(MealType.Lunch, lunchCalories);
            var dinner = GetClosestMeal(MealType.Dinner, dinnerCalories);

            return new MealPlan
            {
                Breakfast = breakfast,
                Lunch = lunch,
                Dinner = dinner,
                TotalCalories = breakfast.Calories + lunch.Calories + dinner.Calories
            };
        }

        private Meal GetClosestMeal(MealType type, int targetCalories)
        {
            return MealDatabase
                .Where(m => m.Type == type)
                .OrderBy(m => Math.Abs(m.Calories - targetCalories))
                .First();
        }
    }

    public class MealPlan
    {
        public Meal Breakfast { get; set; } = new Meal();
        public Meal Lunch { get; set; } = new Meal();
        public Meal Dinner { get; set; } = new Meal();
        public int TotalCalories { get; set; }
    }

    public class Meal
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Calories { get; set; }
        public MealType Type { get; set; }
    }

    public enum MealType
    {
        Breakfast,
        Lunch,
        Dinner
    }
}
