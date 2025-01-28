using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeYade_Blog.Web.Pages
{
    public class CustomModel : PageModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void OnGet()
        {
            Name = "Hosein";
            Age = 100;
        }
        public IActionResult Onpost()
        {
            return Redirect("/");
        }
    }
}
