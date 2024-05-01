//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Measures
{
    public class MeasureDeleteModel : PageModel
    {
        public readonly IService<Measure, int> _service;

        public MeasureDeleteModel(IService<Measure, int> service)
        {
            _service = service;
        }

        public User User { get; set; }
        public IActionResult OnGet(int id)
        {
            GetUser();
            _service.Delete(id);
            return Redirect("/Measures/MeasureRetrieveAll");

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
