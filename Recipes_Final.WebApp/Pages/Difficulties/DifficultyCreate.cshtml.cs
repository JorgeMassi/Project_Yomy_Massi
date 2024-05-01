using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Difficulties
{
    public class DifficultyCreateModel : PageModel  
    {
        private readonly IService<Difficulty, int> _difficultyService;
       

        public DifficultyCreateModel(IService<Difficulty, int> difficultyservice)
        {
            _difficultyService = difficultyservice;
            
        }


        public User User { get; set; }
        public Difficulty Difficulty {get; set;}

        public IActionResult OnPost()
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Name = Convert.ToString(Request.Form["name"]);

            _difficultyService.Create(difficulty);
            return Redirect("/Difficulties/DifficultyRetrieveall");
        }


        public void OnGet() 
        {
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
