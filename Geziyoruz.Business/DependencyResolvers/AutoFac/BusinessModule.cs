

using Autofac;
using Geziyoruz.Business.Abstract;
using Geziyoruz.Business.Concrete;

namespace Geziyoruz.Business.DependencyResolvers.AutoFac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<BlogPostManager>().As<IBlogPostService>();
            builder.RegisterType<PictureManager>().As<IPictureService>();


            base.Load(builder);
        }
    }
}
