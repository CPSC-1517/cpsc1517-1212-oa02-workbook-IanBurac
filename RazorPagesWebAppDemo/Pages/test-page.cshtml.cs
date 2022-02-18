using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWebAppDemo.Pages
{
    public class test_pageModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public string Field { get; set; }
        public void OnGet()
        {
            Message = "OnGet() Method Executed";

        }

        public void OnPost()
        {
            Message = $"OnPost() Method Executed with a file value {Field}";
        }
    }
}
