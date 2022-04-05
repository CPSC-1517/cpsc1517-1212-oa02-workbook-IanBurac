using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystemLibrary.DAL; // for WestWindContext
using WestWindSystemLibrary.Entities; // for Product

namespace WestWindSystemLibrary.BLL
{
    public class ProductServices
    {
        // Step 1: Define a readonly public DbContext field that is intialized using
        // constructor injection
        private readonly WestWindContext _dbContext;

        internal ProductServices(WestWindContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Step 2: Define operations to perform with entity
        public List<Product> Product_GetByCategoryID(int categoryID)
        {
            return _dbContext
                .Products.Where(item => item.CategoryID == categoryID)
                .ToList();
        }

        public Product Product_GetByID(int productID)
        {
            return _dbContext
                .Products.Where(item => item.ProductId == item.ProductId)
                .FirstOrDefault();
        }


    }
}
