using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestwindSystem.BLL; // for CategoryServices
using WestwindSystem.Entities; // for Category

namespace WestWindWebApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        #region use dependecy injection to assign value to categoryServices
        private readonly CategoryServices _categoryServices;

        public IndexModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        #endregion

        #region
        public List<Category> CategoryList { get; set; } = new();
        #endregion

        public void OnGet()
        {
            CategoryList = _categoryServices.Category_List();
        }
    }
}
