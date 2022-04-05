using Microsoft.EntityFrameworkCore; // DbContext, DbContextOPtions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestwindSystem.Entities; // Category

namespace WestwindSystem.DAL
{
    internal class WestwindContext : DbContext
    {
        public WestwindContext()
        {

        }
        public WestwindContext(DbContextOptions<WestwindContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<BuildVersion> BuildVersions { get; set; } = null!;
        public DbSet<Region> Regions { get; set; } = null!;
        public DbSet<Territory> Territories { get; set; } = null!;
    }
}
