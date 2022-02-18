using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using UserManager.Configuration;
using UserManager.Repositories;
using UserManager.Repositories.Repositories;
using UserManager.Services.Services;

namespace UserManager
{
    public class DependencyInjection
    {
        private readonly ApplicationSettings _applicationSettings;
        private readonly IServiceCollection _container;
        public DependencyInjection(ApplicationSettings applicationSetting, IServiceCollection container)
        {
            _applicationSettings = applicationSetting;
            _container = container;
        }

        internal void Init()
        {
            _container.AddSingleton(typeof(IRepositoryContext), new RepositoryContext(_applicationSettings.ConnectionString));
            _container.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));
            _container.AddSingleton(typeof(IMemoryCache), new MemoryCache(new MemoryCacheOptions()));

            RegisterSingletons(typeof(UsersService), "Service");
            RegisterSingletons(typeof(UsersRepository), "Repository");
        }

        private void RegisterSingletons(Type anyTypeFromAssembly, string typePostfix)
        {
            var implementationTypes = anyTypeFromAssembly.Assembly.GetExportedTypes().Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith(typePostfix));
            foreach (var implementationType in implementationTypes)
            {
                RegisterSingleton(implementationType);
            }
        }

        private void RegisterSingleton(Type implementationType)
        {
            var interfaceType = GetDefaultInterface(implementationType);
            _container.AddSingleton(interfaceType, implementationType);
        }

        private static Type GetDefaultInterface(Type classType)
        {
            return classType.GetInterface("I" + classType.Name);
        }
    }
}
