// using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Ingredients
{
    public class IngredientModel : PageModel
    {
        private readonly IService<Ingredient, int> _service;

        public IngredientModel(IService<Ingredient, int> service)
        {
            _service = service;
        }

        public List<Ingredient> Ingredients { get; set; }

        public Ingredient Ingredient { get; set; }

        public User User { get; set; }

        public void OnGet()
        {
            Ingredients= _service.RetrieveAll();
            GetUser();
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
