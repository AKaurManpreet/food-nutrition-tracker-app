using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace FoodNutritionTracker.Pages
{
    public class MealSuggestionModel : PageModel
    {
        //MEal data which is get from json file 
        private readonly List<Product> meals = new List<Product>
        {
           new Product
{
    product_name = "Lait",
    ingredients = "lait frais pasteurisé demi écrémé",
    calories = 188
},
new Product
{
    product_name = "Ratatouille cuisinée à la Provençale",
    ingredients = "Dés d'aubergines préfrites 25% (aubergines 22%, huile de tournesol), dés de courgettes 25%, purée de tomates mi-réduite 20%, oignons en dés 13%, poivrons rouges en dés 8%, double concentré de tomate 3%, huile d'olive vierge extra 2%, sucre 1,3%, sel, ail, jus concentré de citron, farine de BLE, thym 0,1%.",
    calories = 82
},
new Product
{
    product_name = "Alvalle Gazpacho l'original",
    ingredients = "Tomate, poivron, concombre, oignon, huile d'olive vierge extra (2,2%), vinaigre de vin, sel, ail, jus de citron, teneur en légumes: 94%",
    calories = 40
},
new Product
{
    product_name = "Salade & Compagnie Manhattan Poulet Roti",
    ingredients = "Salade composée 80% spécialités céréalières cuites (eau, semoule de BLE dur, CEUF, sel, curcuma), CEUF, salade 11%, viande de poulet, carottes, FROMAGE à pâte dure, jus de citron, huile de colza, eau, amidon et/ou fécule, dextrose, ferments, sel, arôme naturel, persil. Sauce vinaigrette balsamique 7% : huile de colza, huile d'olive vierge, vinaigre de vin (SULFITES), moût de raisin, sel. Cookie au chocolat 7% : sucre, farine de BLE, CEUF, BEURRE, huile de colza, pâte et beurre de cacao, poudre de cacao maigre, poudre à lever: bicarbonate de sodium, émulsifiants: lécithines (SOJA), arôme naturel, sel. Gressins 4% et fourchette 2% : farine de BLE, son de BLE, fibre de BLE, semoule de BLE dur, BEURRE, huile d'olive vierge, huile de colza, eau, levure boulangère, sucre, amidon et/ou fécule, sel, graines de pavot, arôme naturel. Ce produit peut contenir du poisson, du soja, de la moutarde, des fruits à coque et d'autres céréales contenant du gluten. Poulet: origine UE",
    calories = 186
},
new Product
{
    product_name = "Tomatsuppe 400g Heinz",
    ingredients = "% Tomatoes (89%), *Water, Modified Cornflour Sugar, Rapeseed Oil, Dried Skimmed Milk, Salt, Cream (Milk), Milk Proteins, Acidity Regulator Citric Acid, Spice Extracts, Herb Extract",
    calories = 54
},
new Product
{
    product_name = "Puy Lentils & French green lentils",
    ingredients = "Puy Lentils (97%) (Water, Puy Lentils), Onion, Olive Oil, Bay Leaf Powder.",
    calories = 138
},
new Product
{
    product_name = "meat feast pizza",
    ingredients = "Turkey, Salted Jersey Butter (4%)(Butter (Milk), Salt), Cornish Sea Salt(1%), Dextrose.",
    calories = 506
},
new Product
{
    product_name = "Baked Beans",
    ingredients = "haricot beans 50%, tomato 35%, water, sugar, modified maize starch, salt, onion powder, ground paprika, flavourings, paprika extract",
    calories = 91
},
new Product
{
    product_name = "Vegetable Soup",
    ingredients = "Carrots, potatoes, peas, beans, onion, celery, vegetable stock.",
    calories = 75
},
new Product
{
    product_name = "Chili Con Carne",
    ingredients = "Beef, beans, tomatoes, chili peppers, garlic, onions, cumin, salt.",
    calories = 320
},
new Product
{
    product_name = "Grilled Chicken Breast",
    ingredients = "Chicken breast, olive oil, garlic, lemon juice, rosemary, salt, pepper.",
    calories = 150
},
new Product
{
    product_name = "Egg Salad",
    ingredients = "Eggs, mayonnaise, mustard, salt, pepper.",
    calories = 210
},
new Product
{
    product_name = "Tuna Salad",
    ingredients = "Tuna, lettuce, olive oil, lemon, salt, pepper.",
    calories = 180
},
new Product
{
    product_name = "Vegan Burger",
    ingredients = "Lentils, rice, spices, vegan bun, lettuce, tomato, onion, ketchup.",
    calories = 350
},
new Product
{
    product_name = "Spaghetti Bolognese",
    ingredients = "Spaghetti, ground beef, tomato sauce, garlic, onions, oregano, basil, olive oil.",
    calories = 400
},
new Product
{
    product_name = "Mac and Cheese",
    ingredients = "Pasta, cheddar cheese, butter, milk, flour, salt.",
    calories = 500
},
new Product
{
    product_name = "Caesar Salad",
    ingredients = "Lettuce, chicken, parmesan, croutons, Caesar dressing.",
    calories = 350
},
new Product
{
    product_name = "Lasagna",
    ingredients = "Lasagna noodles, ground beef, tomato sauce, mozzarella cheese, ricotta cheese.",
    calories = 450
},
new Product
{
    product_name = "Chicken Tikka Masala",
    ingredients = "Chicken, yogurt, curry sauce, garlic, onions, cumin, coriander, ginger.",
    calories = 500
},
new Product
{
    product_name = "Beef Stroganoff",
    ingredients = "Beef, mushrooms, sour cream, garlic, onions, paprika.",
    calories = 520
},
new Product
{
    product_name = "Chicken Fajitas",
    ingredients = "Chicken, bell peppers, onions, tortillas, fajita seasoning.",
    calories = 400
},
new Product
{
    product_name = "Vegetable Stir Fry",
    ingredients = "Broccoli, carrots, bell peppers, soy sauce, olive oil.",
    calories = 220
},
new Product
{
    product_name = "Cheese Pizza",
    ingredients = "Pizza dough, tomato sauce, mozzarella cheese.",
    calories = 300
},
new Product
{
    product_name = "Pepperoni Pizza",
    ingredients = "Pizza dough, tomato sauce, mozzarella cheese, pepperoni.",
    calories = 350
},
new Product
{
    product_name = "Buffalo Wings",
    ingredients = "Chicken wings, buffalo sauce, butter.",
    calories = 250
},
new Product
{
    product_name = "Garlic Bread",
    ingredients = "Bread, garlic, butter, parsley.",
    calories = 180
},
new Product
{
    product_name = "Fruit Salad",
    ingredients = "Apples, oranges, grapes, pineapple, strawberries.",
    calories = 100
},
new Product
{
    product_name = "Smoothie",
    ingredients = "Banana, strawberries, almond milk, honey.",
    calories = 200
},
new Product
{
    product_name = "Grilled Salmon",
    ingredients = "Salmon, olive oil, lemon, garlic, parsley.",
    calories = 250
},
new Product
{
    product_name = "Pasta Primavera",
    ingredients = "Pasta, broccoli, bell peppers, carrots, olive oil, parmesan.",
    calories = 400
},
new Product
{
    product_name = "Vegetable Pizza",
    ingredients = "Pizza dough, tomato sauce, mozzarella cheese, mushrooms, onions, bell peppers.",
    calories = 320
},
new Product
{
    product_name = "Eggplant Parmesan",
    ingredients = "Eggplant, breadcrumbs, marinara sauce, mozzarella cheese, parmesan cheese.",
    calories = 350
},
new Product
{
    product_name = "Beef Tacos",
    ingredients = "Ground beef, taco seasoning, tortillas, lettuce, cheese, salsa.",
    calories = 250
},
new Product
{
    product_name = "Fish Tacos",
    ingredients = "Fish fillets, tortillas, cabbage, lime, salsa.",
    calories = 220
},
new Product
{
    product_name = "Cabbage Salad",
    ingredients = "Cabbage, carrots, olive oil, vinegar, salt.",
    calories = 90
},
new Product
{
    product_name = "Falafel",
    ingredients = "Chickpeas, garlic, onion, parsley, spices.",
    calories = 150
},
new Product
{
    product_name = "Hummus",
    ingredients = "Chickpeas, tahini, olive oil, garlic, lemon juice.",
    calories = 220
},
new Product
{
    product_name = "Chow Mein",
    ingredients = "Noodles, soy sauce, vegetables, tofu, garlic.",
    calories = 300
},
new Product
{
    product_name = "Pad Thai",
    ingredients = "Rice noodles, shrimp, eggs, peanuts, lime, soy sauce.",
    calories = 400
},
new Product
{
    product_name = "Peking Duck",
    ingredients = "Duck, hoisin sauce, pancakes, cucumber, scallions.",
    calories = 500
},
new Product
{
    product_name = "Shrimp Scampi",
    ingredients = "Shrimp, garlic, butter, olive oil, lemon, parsley.",
    calories = 350
},
new Product
{
    product_name = "Chicken Parmesan",
    ingredients = "Chicken, breadcrumbs, marinara sauce, mozzarella cheese, parmesan cheese.",
    calories = 480
},
new Product
{
    product_name = "Pork Ribs",
    ingredients = "Pork ribs, BBQ sauce.",
    calories = 500
},
new Product
{
    product_name = "Beef Burritos",
    ingredients = "Ground beef, beans, rice, tortillas, cheese, salsa.",
    calories = 450
},
new Product
{
    product_name = "Chicken Wings",
    ingredients = "Chicken wings, BBQ sauce, honey.",
    calories = 270
},
new Product
{
    product_name = "Beef Kebabs",
    ingredients = "Beef, onions, bell peppers, skewers, spices.",
    calories = 350
},
new Product
{
    product_name = "Tofu Stir Fry",
    ingredients = "Tofu, soy sauce, broccoli, carrots, onions.",
    calories = 230
},
new Product
{
    product_name = "Pulled Pork Sandwich",
    ingredients = "Pulled pork, BBQ sauce, sandwich bun.",
    calories = 400
},
new Product
{
    product_name = "Lasagna Roll-Ups",
    ingredients = "Lasagna noodles, ground beef, ricotta cheese, marinara sauce, mozzarella cheese.",
    calories = 460
},
new Product
{
    product_name = "Fettuccine Alfredo",
    ingredients = "Fettuccine pasta, heavy cream, butter, parmesan cheese.",
    calories = 550
},
new Product
{
    product_name = "Quiche Lorraine",
    ingredients = "Eggs, cream, bacon, cheese, pie crust.",
    calories = 400
},
new Product
{
    product_name = "Crispy Fried Chicken",
    ingredients = "Chicken, flour, spices, oil.",
    calories = 450
},
new Product
{
    product_name = "Cheese and Cracker Platter",
    ingredients = "Cheese, crackers, grapes.",
    calories = 150
},
new Product
{
    product_name = "Meatball Sub",
    ingredients = "Meatballs, marinara sauce, mozzarella cheese, sub roll.",
    calories = 550
},
new Product
{
    product_name = "Grilled Cheese",
    ingredients = "Bread, butter, cheddar cheese.",
    calories = 250
},
new Product
{
    product_name = "Stuffed Peppers",
    ingredients = "Bell peppers, ground beef, rice, cheese.",
    calories = 300
},
new Product
{
    product_name = "Chicken Caesar Wrap",
    ingredients = "Chicken, Caesar dressing, lettuce, tortilla.",
    calories = 350
},
new Product
{
    product_name = "Turkey Club",
    ingredients = "Turkey, bacon, lettuce, tomato, mayo, bread.",
    calories = 400
},
new Product
{
    product_name = "Vegan Burrito",
    ingredients = "Rice, beans, guacamole, salsa, tortilla.",
    calories = 350
},
new Product
{
    product_name = "Prawn Cocktail",
    ingredients = "Shrimp, cocktail sauce, lettuce.",
    calories = 150
},
new Product
{
    product_name = "French Fries",
    ingredients = "Potatoes, oil, salt.",
    calories = 200
},
new Product
{
    product_name = "Churros",
    ingredients = "Flour, sugar, butter, oil, cinnamon.",
    calories = 250
},
new Product
{
    product_name = "Tiramisu",
    ingredients = "Mascarpone cheese, espresso, cocoa, ladyfingers, eggs.",
    calories = 400
},
new Product
{
    product_name = "Ice Cream Sundae",
    ingredients = "Ice cream, chocolate sauce, whipped cream, nuts.",
    calories = 350
},
new Product
{
    product_name = "Chocolate Cake",
    ingredients = "Flour, cocoa, sugar, butter, eggs.",
    calories = 450
},
new Product
{
    product_name = "Apple Pie",
    ingredients = "Apples, sugar, cinnamon, pie crust.",
    calories = 300
},
new Product
{
    product_name = "Banana Bread",
    ingredients = "Bananas, flour, sugar, eggs, butter.",
    calories = 350
}

        };

        [BindProperty]
        public int DailyCalories { get; set; }

        public MealPlan MealPlan { get; private set; } = new MealPlan();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Form is not valid");
                return Page();
            }

            MealPlan = await GenerateMealPlanAsync(DailyCalories);
            return Page();
        }

        private async Task<MealPlan> GenerateMealPlanAsync(int dailyCalories)
        {
            int breakfastCalories = (int)(dailyCalories * 0.25);
            int lunchCalories = (int)(dailyCalories * 0.35);
            int dinnerCalories = (int)(dailyCalories * 0.40);

            var breakfast = await GetClosestMealAsync(MealType.Breakfast, breakfastCalories);
            var lunch = await GetClosestMealAsync(MealType.Lunch, lunchCalories);
            var dinner = await GetClosestMealAsync(MealType.Dinner, dinnerCalories);

            return new MealPlan
            {
                Breakfast = breakfast,
                Lunch = lunch,
                Dinner = dinner,
                TotalCalories = breakfast.Calories + lunch.Calories + dinner.Calories
            };
        }

        private async Task<Meal> GetClosestMealAsync(MealType type, int targetCalories)
        {
            // Find the meal with the closest calories to targetCalories
            var meal = meals
                .Where(p => p.calories > 0)  // Ensure valid calories
                .OrderBy(p => Math.Abs(p.calories - targetCalories))  // Find closest match
                .FirstOrDefault();

            if (meal != null)
            {
                return new Meal
                {
                    Name = meal.product_name ?? "Unknown Meal",
                    Description = meal.ingredients ?? "No description available",
                    Calories = meal.calories,
                    Type = type
                };
            }

            return new Meal { Name = "No Meal Found", Description = "No suitable meal in the database", Calories = targetCalories, Type = type };
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

    public class Product
    {
        public string? product_name { get; set; }
        public string? ingredients { get; set; }
        public int calories { get; set; }
    }
}
