using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestwindSystem.DAL; // for WestWindContext
using WestwindSystem.Entities; // for Category

namespace WestwindSystem.BLL
{
    public class CategoryServices
    {
        #region Setup a dbcontext
        // Define a readonly field for the datatbase context that will be assigned a value in the constructor
        private readonly WestwindContext _context;

        internal CategoryServices(WestwindContext context)
        {
            _context = context;
        }
        #endregion

        public List<Category> Category_List()
        {
            return _context.Categories.OrderBy(currentItem => currentItem.CategoryName).ToList();
        }

        public Category? Category_GetById(int categoryId)
        {
            return _context.Categories.Where(currentItem => currentItem.CategoryId == categoryId).FirstOrDefault();
        }

        public List<Category> Category_GetByPartialDescription(string partialDescription)
        {
            return _context.Categories.Where(currentItem => currentItem.Description.Contains(partialDescription)).ToList();
        }
    }
}
