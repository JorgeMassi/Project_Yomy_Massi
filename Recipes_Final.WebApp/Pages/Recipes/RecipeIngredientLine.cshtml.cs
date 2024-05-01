//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Service.Interface;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Recipes
{
    public class RecipeIngredientLineModel : PageModel
    {
        private readonly IService<Recipe, int> _recipeService;
        private readonly IIngLineService _ingLineService;
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;

        public RecipeIngredientLineModel(IService<Recipe, int> recipeService, IIngLineService ingLineService, IService<Ingredient, int> ingredientService, IService<Measure, int> measureService)
        {
            _recipeService = recipeService;
            _ingLineService = ingLineService;
            _ingredientService = ingredientService;
            _measureService = measureService;
        }

        public Recipe Recipe { get; set; }
        public List<Recipe> Recipes { get; set; }
        public User User { get; set; }
        public List<IngredientLine> IngredientLines { get; set; }
        public IngredientLine IngredientLine { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Ingredient Ingredient { get; set; }
        public Measure Measure { get; set; }
        public List<Measure> Measures { get; set; }



        public void OnGet(int id)
        {
            GetUser();
            Recipe = _recipeService.Retrieve(id);
            IngredientLines = _ingLineService.RetrieveAllByRecipeId(Recipe);
            Ingredients = _ingredientService.RetrieveAll();
            Measures = _measureService.RetrieveAll();

        }

       /* public void OnPost()

        {
            IngredientLine ingredientLine = new IngredientLine();

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);
            ingredientLine.Recipe = recipe;

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);
            ingredientLine.Ingredient = ingredient;

            ingredientLine.Quantity = Convert.ToDouble(Request.Form["quantity"]);

            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(Request.Form["id_measure"]);
            ingredientLine.Measure = measure;
        }*/

        private void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }

        }


    }
}
