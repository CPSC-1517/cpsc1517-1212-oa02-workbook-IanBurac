using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWebAppDemo.Pages
{
    public class FormFieldControlsUsingTagHelpersModel : PageModel
    {
        // Define an auto-implemented property for feedback messages
        public string Message { get; set; }
        // Define an auto-implemented property for username
        [BindProperty] // Binds a HTML form field to this property
        public string Username { get; set; }
        // Define an auto-implemented property for password
        [BindProperty]
        public string Password { get; set; }
        // Define an auto-implemented property for confirmed password
        [BindProperty]
        public string ConfirmPassword { get; set; }
        // Create a method to handle a HTTP Post request

        public void OnPost()
        {
            // Check if the Password matches the ConfirmPassword
            if (Password == ConfirmPassword)
            {
                Message = $"You submitted the following: {Username}, {Password}";
            }
            else
            {
                Message = $"The password and confirm password does not match.";
            }
        }
        public void OnGet()
        {
        }
    }
}
