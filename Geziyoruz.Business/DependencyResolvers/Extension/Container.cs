

using Geziyoruz.DataAccess.Abstract;
using Geziyoruz.DataAccess.Concrete.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Geziyoruz.Business.DependencyResolvers.Extension
{
    public static class Container
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddScoped<IAdminDal, AdminDal>();
            services.AddScoped<IBlogPostDal, BlogPostDal>();
            services.AddScoped<ICustomerDal, CustomerDal>();
            services.AddScoped<IPictureDal, PictureDal>();

            return services;
        }
    }
}
