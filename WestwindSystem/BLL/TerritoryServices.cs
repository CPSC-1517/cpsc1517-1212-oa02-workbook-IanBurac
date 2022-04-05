using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestwindSystem.DAL; // for WestwindContext
using WestwindSystem.Entities; // for Territory and Region

namespace WestwindSystem.BLL
{
    public class TerritoryServices
    {
        // Define a readonly data filed for the Dbcontext
        private WestwindContext _context;

        // Degine a greedy constructor for initializing the Dbcontext
        internal TerritoryServices(WestwindContext context)
        {
            _context = context;
        }

        public List<Territory> GetByRegion(int regionID)
        {
            IEnumerable<Territory> queryResult = _context.Territories.Where(currentItem => currentItem.RegionID == regionID).OrderBy(currentItem => currentItem.TerritoryDescription);
            return queryResult.ToList();
        }
    }
}
