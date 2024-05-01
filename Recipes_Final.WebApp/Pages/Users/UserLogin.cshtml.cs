using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Service.Interface;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Users
{
    public class UserLoginModel : PageModel
    {
        private readonly IUserService _service;


        public UserLoginModel(IUserService service)
        {
            _service = service;
        }

        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
        }
        public IActionResult OnPost()
        {
            if (SetUser())
            {

                return Redirect("/Index");
            }
            else
            {
                return Redirect("/Users/UserLogin");
            }
        }
        public bool SetUser()
        {
            string username = Convert.ToString(Request.Form["username"]);
            string password = Convert.ToString(Request.Form["password"]);

            User u = _service.Login(username, password);

            string jsonString = JsonSerializer.Serialize(u);
            HttpContext.Session.SetString("user", jsonString);
            return true;    
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
