using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Service.Interface;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Recipes
{
    public class RecipeModel : PageModel
    {
        private readonly IService<Recipe, int> _recipeService;
        private readonly IUserService _userService;
        private readonly IService<Category, int> _categoryService;
        private readonly IService<Difficulty, int> _difficultyService;
        private readonly IIngLineService _ingLineService;

        public RecipeModel(IService<Recipe, int> recipeService, IUserService userService, IService<Category, int> categoryService, IService<Difficulty, int> difficultyService, IIngLineService ingLineService)
        {
            _recipeService = recipeService;
            _userService = userService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _ingLineService = ingLineService;
        }

        public List<Recipe> Recipes { get; set; }

        public Recipe Recipe { get; set; }

        public List<Category> Categories { get; set; }
        public Category Category { get; set; }

        public List<Difficulty> Difficulties { get; set; }
        public Difficulty Difficulty { get; set; }

        public List<IngredientLine> IngredientLines { get; set; }
        public User User { get; set; }

        public void OnGet()
        {
            Recipes = _recipeService.RetrieveAll();
            //Category = _categoryService.Retrieve(Category.Id);
            Categories = _categoryService.RetrieveAll();
            Difficulties = _difficultyService.RetrieveAll();
           
            GetUser();
            foreach (Recipe recipe in Recipes)
            {
                recipe.Author = _userService.Retrieve(recipe.Author.Id);
                recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);
                recipe.Category = _categoryService.Retrieve(recipe.Category.Id);
                recipe.ingredientLines = _ingLineService.RetrieveAllByRecipeId(recipe);

            }
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
}//
