using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Service.Interface;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Users
{
    public class UserRetrieveAllModel : PageModel
    {
        private readonly IUserService _service;
				

		public UserRetrieveAllModel(IUserService service)
        {
            _service = service;
        }

        public List<User> Users { get; set; }

        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
            Users = _service.RetrieveAll();
            User = _service.Retrieve(User.Id);
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
