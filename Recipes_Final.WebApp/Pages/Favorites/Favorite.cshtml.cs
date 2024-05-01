//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Favorites
{
    public class FavoriteModel : PageModel
    {
        private readonly IService<Favorite, int> _service;

        public FavoriteModel(IService<Favorite, int> service)
        {
            _service = service;
        }
        public List<Favorite> Favorites { get; set; }
        public User User { get; set; }


        public void OnGet()
        {
            Favorites = _service.RetrieveAll();
            GetUser();
        }

        public IActionResult OnPost()
        {
            Favorite favorite = new Favorite();
            favorite.User.Id = Convert.ToInt32(Request.Form["id_users"]);
            favorite.Recipe.Id = Convert.ToInt32(Request.Form["id_recipes"]);

            _service.Create(favorite);
            return Redirect("/Favorites/retrieveall");

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
