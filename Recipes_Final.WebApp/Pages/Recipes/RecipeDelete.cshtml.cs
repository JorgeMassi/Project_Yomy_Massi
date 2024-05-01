//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Recipes
{
    public class RecipeDeleteModel : PageModel
    {
        public IService<Recipe, int> _service;

        public RecipeDeleteModel(IService<Recipe, int> service)
        {
            _service = service;
        }

        public Recipe Recipe { get; set; }
        public User User { get; set; }
        public IActionResult OnGet(int id)
        {
            GetUser();
            _service.Delete(id);
            return Redirect("/Recipes/RecipeRetrieveAll");
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
