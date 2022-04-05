using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestwindSystem.BLL; // for CategoryServices
using WestwindSystem.Entities; // for Category

namespace WestWindWebApp.Pages.Categories
{
    public class QueryByIdModel : PageModel
    {
        // Define a readonly field for CategoryServices
        private readonly CategoryServices _categoryServices;

        // Define greedy constructor with a CategoryServices that is injected by the Backend extension
        public QueryByIdModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        //Define an auto-implemented property for feedback messages
        [TempData]
        public string FeedbackMessage { get; set; }

        //Define an auto-implemented property for the search value
        [BindProperty(SupportsGet = true)] // allow this property to matched to a route
        public int searchId { get; set; }

        //Define an auto-implemented property for the search result
        public Category searchSingleResult { get; set; }

        public void OnGet()
        {
            if(searchId > 0)
            {
                searchSingleResult = _categoryServices.Category_GetById(searchId);
                if (searchSingleResult == null)
                {
                    FeedbackMessage = $"No result returned for Category id. {searchId}";
                }
                else
                {
                    FeedbackMessage = $"<tr><td>{searchSingleResult.CategoryId}</td>" +
                        $"<td>{searchSingleResult.CategoryName} </td>" +
                        $"<td>{searchSingleResult.Description}</td></tr> ";
                }
            }
        }
        public IActionResult OnPostFetch()
        {
            //Check if the search value is valid
            if (searchId <= 0)
            {
                FeedbackMessage = "Required: Enter a category id to search for";
            }

            return RedirectToPage(new { searchId = searchId});
        }
    }
}
