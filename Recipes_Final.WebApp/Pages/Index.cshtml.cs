using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.Model;
using Recipes_Final.Service.Interface;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Claims;

namespace Recipes_Final.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserService _userService;

        public IndexModel(ILogger<IndexModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public User User { get; set; }
        public List<User> Users { get; set; }

        public void OnGet()
        {
            GetUser();//
            Users =_userService.RetrieveAll();   

           
        }
        private void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
            //else
            //{
            //    HttpContext.Session.Clear();
            //    Redirect("/Index");
            //}
        }
    }
}