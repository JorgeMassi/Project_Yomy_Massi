//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Service.Interface;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Recipes
{
    public class RecipeUpdateModel : PageModel
    {
        private readonly IService<Recipe, int> _recipeService;
        private readonly IService<Category, int> _categoryService;
        private readonly IService<Difficulty, int> _difficultyService;
        private readonly IUserService _userService;

        public RecipeUpdateModel(IService<Recipe, int> recipeService, IService<Category, int> categoryService, IService<Difficulty, int> difficultyService, IUserService userService)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _userService = userService;
        }

        public Recipe Recipe { get; set; }
        public List<Recipe> Recipes { get; set; }

        public Category Category { get; set; }  
        public List<Category> Categories { get; set; }

        public Difficulty Difficulty { get; set; }
        public List<Difficulty> Difficulties { get; set; }

        public User User { get; set; }
        public List<User> Users { get; set; }


        public void OnGet(int id)
        {
            GetUser();
            Recipe = _recipeService.Retrieve(id);
            Categories= _categoryService.RetrieveAll();
            Difficulties= _difficultyService.RetrieveAll();
            Users = _userService.RetrieveAll();
        }

        public IActionResult OnPost()
        {

            Recipe recipe = new Recipe();
            recipe.Title = Convert.ToString(Request.Form["title"]);
            recipe.Id = Convert.ToInt32(Request.Form["id"]);

            User user = new User();
            user.Id = Convert.ToInt32(Request.Form["id_user"]);
            recipe.Author = user;

            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["id_category"]);
            recipe.Category = category;

            recipe.PreparationTime = Convert.ToInt32(Request.Form["prep_time"]);
            recipe.PreparationMethod = Convert.ToString(Request.Form["prep_method"]);

            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(Request.Form["id_difficulty"]);
            recipe.Difficulty = difficulty;

            recipe.IsApproved = true;

            recipe = _recipeService.Update(recipe);
            return Redirect($"/Recipes/RecipeRetrieveAll");// IngredientsUpdate?id={recipe.Id}");
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
