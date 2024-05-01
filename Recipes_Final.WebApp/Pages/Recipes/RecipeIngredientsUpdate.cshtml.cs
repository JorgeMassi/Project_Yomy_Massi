//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Service.Interface;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Recipes
{
    public class RecipeIngredientsUpdateModel : PageModel
    {

        private readonly IIngLineService _inglineService;
        private readonly IService<Ingredient, int> _serviceIngredient;
        private readonly IService<Recipe, int> _serviceRecipe;
        private readonly IService<Measure, int> _serviceMeasure;
        private readonly IUserService _userService;

        public RecipeIngredientsUpdateModel(IIngLineService inglineService, IService<Ingredient, int> serviceIngredient, IService<Recipe, int> serviceRecipe, IService<Measure, int> serviceMeasure, IUserService userService)
        {
            _inglineService = inglineService;
            _serviceIngredient = serviceIngredient;
            _serviceRecipe = serviceRecipe;
            _serviceMeasure = serviceMeasure;
            _userService = userService;
        }

        public IngredientLine IngredientLine { get; set; }
        public List<IngredientLine> IngredientLines { get; set; }

        public Ingredient Ingredient { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Measure Measure { get; set; }

        public List<Measure> Measures { get; set; }

        public User User { get; set; }
        public void OnGet()
        {
            GetUser();
            IngredientLine = _inglineService.Retrieve(IngredientLine.Id);
            Ingredients = _serviceIngredient.RetrieveAll();
            Measures = _serviceMeasure.RetrieveAll();
            IngredientLines = _inglineService.RetrieveAll();
        }

        public IActionResult OnPost()
        {
            IngredientLine ingline = new IngredientLine();
            ingline.Id = Convert.ToInt32(Request.Form["ingline_id"]);

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);
            ingline.Recipe.Id = recipe.Id;

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);
            ingline.Ingredient = ingredient;

            ingline.Quantity = Convert.ToDouble(Request.Form["quantity"]);

            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(Request.Form["id_measure"]);

            ingline = _inglineService.Update(ingline);
            return Redirect($"/Recipes/RecipeIngredientsLine?id={recipe.Id}");
        }
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
