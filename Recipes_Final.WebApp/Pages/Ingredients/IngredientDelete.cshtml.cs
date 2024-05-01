//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Ingredients
{
    public class IngredientDeleteModel : PageModel
    {
        public readonly IService<Ingredient, int> _service;

        public IngredientDeleteModel(IService<Ingredient, int> service)
        {
            _service = service;
        }

        public User User { get; set; }
        public IActionResult OnGet(int id)
        {
            GetUser();
            _service.Delete(id);
            return Redirect("/Ingredients/IngredientRetrieveAll");

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
