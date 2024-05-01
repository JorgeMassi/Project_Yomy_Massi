//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Measures
{
    public class MeasuresCreateModel : PageModel
    {
        public readonly IService<Measure, int> _service;

        public MeasuresCreateModel(IService<Measure, int> service)
        {
            _service = service;
        }
        public User User { get; set; }
    public Measure Measure {get; set;}

        public IActionResult OnPost()
        {
            Measure measure = new Measure();
            measure.Name = Convert.ToString(Request.Form["name"]);

            _service.Create(measure);

            return Redirect("/Measures/MeasureRetrieveAll");
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
