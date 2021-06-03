using Haulio.FarmFresh.BusinessLogic.Services;
using Haulio.FarmFresh.DAL.DataContext;
using Haulio.FarmFresh.DAL.Repositories;
using Haulio.FarmFresh.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Haulio.FarmFresh.IoC
{
    public class DependencyInjection
    {
        private readonly IConfiguration Configuration;
        public DependencyInjection(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void InjectDependencies(IServiceCollection services)
        {
            services.AddDbContext<FarmFreshDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("farmfreshdb"));
            });

            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
