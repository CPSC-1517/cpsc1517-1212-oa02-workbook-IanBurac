using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestwindSystem.BLL; // for CategoryServices
using WestwindSystem.Entities; // for Category

namespace WestWindWebApp.Pages.Categories
{
    public class QueryByPartialDescriptionModel : PageModel
    {
        // Define a readonly field for CategoryServices
        private readonly CategoryServices _categoryServices;

        public QueryByPartialDescriptionModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public string FeedbackMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Searchvalue { get; set; }

        public List<Category> SearchResultList { get; set; } = new();

        public IActionResult OnPostFetch()
        {
            if (string.IsNullOrWhiteSpace(Searchvalue))
            {
                FeedbackMessage = "Search value is required";
            }
            return RedirectToPage(new { Searchvalue = Searchvalue });
        }

        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            SearchResultList.Clear();
            ModelState.Clear();
            return RedirectToPage();
        }

        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(Searchvalue))
            {
                SearchResultList = _categoryServices.Category_GetByPartialDescription(Searchvalue);
                if (SearchResultList.Count == 0)
                {
                    FeedbackMessage = "No results returned";
                }
            }
        }
    }
}
