using BackEnd.Api.Abstractions;
namespace BackEnd.Api.Api.Extensions
{
    public static class ModuleExtensions
    {
        private static List<IModule> _modules = new List<IModule>();
        public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
        {
            _modules = DiscoverModules();
            foreach(var module in _modules)
            {
                module.RegisterModule(builder);
            }
            return builder;

        }
        public static WebApplication MapEndPoints(this WebApplication app)
        {
            foreach(var module in _modules)
            {
                module.MapEnpoints(app);
            }
            return app;

        }
        private static List<IModule> DiscoverModules()
        {
            return typeof(IModule).Assembly.GetTypes().Where(m => m.IsClass && m.IsAssignableTo(typeof
                (IModule))).Select(Activator.CreateInstance).Cast<IModule>().ToList();
        }
    }
}
