using Infrastructure.Autowiring;
using System.Web.Http;
using SimpleInjector.Integration.WebApi;

namespace refactor_me
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = Boostrapper.ConfigureServices();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
