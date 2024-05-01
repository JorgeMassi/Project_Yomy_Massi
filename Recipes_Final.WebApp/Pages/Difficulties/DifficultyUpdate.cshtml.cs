using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Difficulties
{
    public class DifficultyUpdateModel : PageModel
    {
        private readonly IService<Difficulty, int> _service;

        public DifficultyUpdateModel(IService<Difficulty, int> service)
        {
            _service = service;
        }

        public Difficulty Difficulty { get; set; }

        public User User { get; set; }  
        public void OnGet(int id)
        {
            Difficulty = _service.Retrieve(id);
            GetUser();
        }

        public IActionResult OnPost()
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(Request.Form["id"]);
            difficulty.Name = Convert.ToString(Request.Form["name"]);
            _service.Update(difficulty);

            return Redirect("/Difficulties/DifficultyRetrieveAll");

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
