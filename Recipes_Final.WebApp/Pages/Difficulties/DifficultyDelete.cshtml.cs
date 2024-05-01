using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Difficulties
{
    public class DifficultyDeleteModel : PageModel
    {
        private readonly IService<Difficulty, int> _service;

        public DifficultyDeleteModel(IService<Difficulty, int> service)
        {
            _service = service;
        }


        User User { get; set; }
        public IActionResult OnGet(int id)
        {
            _service.Delete(id);
            GetUser();

            return Redirect("/Difficulties/DifficultyRetrieveAll");
        }

        public void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
