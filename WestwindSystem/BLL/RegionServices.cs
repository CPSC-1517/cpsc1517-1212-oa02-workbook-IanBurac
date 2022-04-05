using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestwindSystem.DAL; // for dbContext
using WestwindSystem.Entities; // for Regions

namespace WestwindSystem.BLL
{
    public class RegionServices
    {
        #region Setup a dbcontext
        //Define a readonly field for the datatbase context that will be assigned a value in the constructor
        private readonly WestwindContext _context;

        internal RegionServices(WestwindContext context)
        {
            _context = context;
        }
        #endregion

        public List<Region> Region_List()
        {
            return _context.Regions.OrderBy(currentItem => currentItem.RegionDescription).ToList();
        }

        public Region? Region_GetById(int RegionId)
        {
            return _context.Regions.Where(currentItem => currentItem.RegionId == RegionId).FirstOrDefault();
        }
    }
}
