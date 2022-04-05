using Microsoft.EntityFrameworkCore; // for DbContextOptionsBuilder
using Microsoft.Extensions.DependencyInjection; // for IServiceCollection
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystemLibrary.BLL; // for the Services
using WestWindSystemLibrary.DAL; // for WestWindContext

namespace WestWindSystemLibrary
{
    public static class BackendExtensions
    {
        public static void BackendDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<WestWindContext>(options);

            services.AddTransient<CategoryServices>((serviceProvider) =>
            {
                var dbContext = serviceProvider.GetService<WestWindContext>();
                return new CategoryServices(dbContext);
            });

            services.AddTransient<ProductServices>((serviceProvider) =>
            {
                var dbContext = serviceProvider.GetService<WestWindContext>();
                return new ProductServices(dbContext);
            });
        }
    }
}
