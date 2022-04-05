using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystemLibrary.DAL; // for WestWindContext
using WestWindSystemLibrary.Entities; // for Category

namespace WestWindSystemLibrary.BLL
{
    public class CategoryServices
    {
        // Step 1: Define a readonly data field for the custom DbContext class
        // and use constructor injection to set the value of the data field
        private readonly WestWindContext _dbContext;

        internal CategoryServices(WestWindContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Step 2: Define query methods of the Category entity
        public List<Category> Category_List()
        {
            IEnumerable<Category> resultListQuery = _dbContext
                .Categories.OrderBy(item => item.CategoryName);
            return resultListQuery.ToList();
        }

        public Category Category_GetById(int categoryID)
        {
            IEnumerable<Category> singleResultQuery = _dbContext
                .Categories.Where(item => item.CategoryID == categoryID);
            return singleResultQuery.FirstOrDefault();
        }

        public List<Category> Category_GetByPartialCategoryNameOrDescription(string partialNameOrDescription)
        {
            IEnumerable<Category> resultListQuery = _dbContext
                .Categories.Where(item => 
                item.CategoryName.Contains(partialNameOrDescription) || item.Description.Contains(partialNameOrDescription));
            return resultListQuery.ToList();
        }
    }
}
