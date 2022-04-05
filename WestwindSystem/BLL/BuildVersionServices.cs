using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestwindSystem.DAL; // WestWindContext
using WestwindSystem.Entities;

namespace WestwindSystem.BLL
{
    public class BuildVersionServices
    {
        private readonly WestwindContext _context;

        internal BuildVersionServices(WestwindContext context)
        {
            _context = context;
        }

        public BuildVersion? GetBuildVersion()
        {
            return _context.BuildVersions.FirstOrDefault();
        }
    }
}
