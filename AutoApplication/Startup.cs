using AutoApplication.DataLibrary.BusinessLogic;
using AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic;
using AutoApplication.DataLibrary.BusinessLogic.SaleBusinessLogic;
using AutoApplication.DataLibrary.BusinessLogic.UserBusinessLogic;
using AutoApplication.DataLibrary.DataAccess;
using AutoApplication.DataLibrary.DataAccessServices;
using AutoApplication.DataLibrary.Model;
using AutoApplication.DataLibrary.ModelServices;
using AutoApplication.Models;
using AutoApplication.ViewModel;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(AutoApplication.Startup))]
namespace AutoApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // REGISTER DEPENDENCIES
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>().InstancePerRequest();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();


            builder.RegisterType<Auto>().As<IAuto>();
            builder.RegisterType<Customer>().As<ICustomer>();
            builder.RegisterType<Payment>().As<IPayment>();
            builder.RegisterType<Sale>().As<ISale>();
            builder.RegisterType<Roles>().As<IRoles>();

            builder.RegisterType<AutoSalesViewModel>();

            builder.RegisterType<SqlServerFindData>().As<ISqlServerFindData>();
            builder.RegisterType<AutoDataProcessor>().As<IAutoDataProcessor>();

            builder.RegisterType<UserDataProcessor>().As<IUserDataProcessor>();

            builder.RegisterType<SqlServerDataModification>().As<ISqlServerDataModification>();
            builder.RegisterType<SalesDataProcessor>().As<ISalesDataProcessor>();

            // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // BUILD THE CONTAINER
            var container = builder.Build();

            // REPLACE THE MVC DEPENDENCY RESOLVER WITH AUTOFAC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // REGISTER WITH OWIN
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            ConfigureAuth(app);
        }
    }
}
