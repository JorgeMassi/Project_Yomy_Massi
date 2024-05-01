using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Categories
{
    public class CategoryRetrieveAllModel : PageModel
    {
        private readonly IService<Category, int> _service;

        public CategoryRetrieveAllModel(IService<Category, int> service)
        {
            _service = service;
        }

        public List<Category> Categories { get; set; }
        public Category Category { get; set; }

        public User User { get; set; }



        public void OnGet()
        {

            Categories = _service.RetrieveAll();
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
