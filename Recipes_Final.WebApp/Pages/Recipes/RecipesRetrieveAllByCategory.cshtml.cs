using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Service.Interface;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Recipes
{
    public class RecipesRetrieveAllByCategoryModel : PageModel
    {
        private readonly ISearchService _searchService;
        private readonly IService<Category, int> _categoryService;
        private readonly IService<Difficulty, int> _difficultyService;
        private readonly IUserService _userService;
        private readonly IService<Recipe, int> _recipeService;

        public RecipesRetrieveAllByCategoryModel(ISearchService searchService, IService<Category, int> categoryService, IService<Difficulty, int> difficultyService, IUserService userService, IService<Recipe, int> recipeService)
        {
            _searchService = searchService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _userService = userService;
            _recipeService = recipeService;
        }

        public List<Category> Categories { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Difficulty> Difficulties { get; set; }
        public List<Search> Searches { get; set; }
        public Search Search { get; set; }

        public User User { get; set; }

        public void OnGet(int catid)
        {
            GetUser();
            Searches =_searchService.RetrieveRetrieveAllByCategory(catid);
            Categories = _categoryService.RetrieveAll();
            Difficulties = _difficultyService.RetrieveAll();
        }

        public void OnPost()
        {
            Search recipe = new Search();
            recipe.Title = Convert.ToString(Request.Form["title"]);

            User user = new User();
            user.Id = Convert.ToInt32(Request.Form["id_user"]);
            recipe.Author = user;

            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["id_category"]);
            recipe.Category = category;

            recipe.PreparationTime = Convert.ToInt32(Request.Form["prep_time"]);
            recipe.PreparationMethod = Convert.ToString(Request.Form["prep_methods"]);

            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(Request.Form["id_difficulty"]);
            recipe.Difficulty = difficulty;

          //
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
