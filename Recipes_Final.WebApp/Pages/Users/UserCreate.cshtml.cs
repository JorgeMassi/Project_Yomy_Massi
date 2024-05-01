using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Service.Interface;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Users
{
    public class UserCreateModel : PageModel
    {
        private readonly IUserService _service;
		


		public UserCreateModel(IUserService service)
        {
            _service = service;
        }

        public List<User> Users { get; set; }
		public User User { get; set; }

        public void OnGet()
        {
            GetUser();
        }


        public IActionResult OnPost()
        {
            User user = new User();

            user.Username = Convert.ToString(Request.Form["username"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            user.Name = Convert.ToString(Request.Form["name"]);


            _service.Create(user);

            return Redirect("/Index");
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
