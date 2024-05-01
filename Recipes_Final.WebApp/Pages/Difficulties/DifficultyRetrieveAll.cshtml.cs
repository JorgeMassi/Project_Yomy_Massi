using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Difficulties
{
    public class DifficultyModel : PageModel
    {
        private readonly IService<Difficulty, int> _service;


        public DifficultyModel(IService<Difficulty, int> service)
        {
            _service = service;
        }


        public List<Difficulty> Difficulties { get; set; }

        public User User { get; set; }
        public void OnGet()
        {
            Difficulties = _service.RetrieveAll();
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
