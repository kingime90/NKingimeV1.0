using Microsoft.Owin;
using Owin;
using NKingime.Core.Dependency;
using NKingime.Web.Mvc;
using NKingime.Core.Initializer;

[assembly: OwinStartupAttribute(typeof(NKingime.App.Mvc.Startup))]
namespace NKingime.App.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IServiceCollection services = new ServiceCollection();
            IServiceBuilder builder = new ServiceBuilder();
            builder.Build(services);

            IIocBuilder mvcIocBuilder = new MvcAutofacIocBuilder(services);
            IContextInitializer initializer = new ContextInitializer();
            initializer.Initialize(mvcIocBuilder);

            ConfigureAuth(app);
        }
    }
}
