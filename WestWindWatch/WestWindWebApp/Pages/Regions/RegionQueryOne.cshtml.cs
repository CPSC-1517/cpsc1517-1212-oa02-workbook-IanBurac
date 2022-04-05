using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestwindSystem.BLL; // for RegionServices
using WestwindSystem.Entities; // for Region

namespace WestWindWebApp.Pages.Regions
{
    public class RegionQueryOneModel : PageModel
    {
        #region Inject a RegionServices into the constructor of the page model
        private readonly RegionServices _regionServices;
        
        public RegionQueryOneModel(RegionServices regionServices)
        {
            _regionServices = regionServices;
        }
        #endregion

        #region Define properties accessed by the web page
        [TempData]
        public string FeedbackMessage { get; set; }
        [BindProperty(SupportsGet = true)] // Bind this property using a router
        public int RegionID { get; set; }
        public Region QuerySingleResult { get; set; }
        #endregion

        #region Define a page handler to perform the search by RegionID
        public IActionResult OnPostSeach()
        {
            // Check if a valid RegionID( >0) has been assigned
            if(RegionID < 1)
            {
                FeedbackMessage = "RegionID is required and must greater than zero";
            }
            //redirect to the same page and pass into the routeValue RegionID
            return RedirectToPage(new {RegionID = RegionID});
        }

        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            ModelState.Clear();
            return RedirectToPage(new { RegionID = (int?) null});
        }
        #endregion
        public void OnGet()
        {
            
        }
    }
}
