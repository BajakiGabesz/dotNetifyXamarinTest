using System;
using Autofac;
using DotNetify;
using DotNetify.Client;
using Microsoft.Extensions.DependencyInjection;
using Test.Helpers;
using Test.ViewModels;

namespace Test.Bootstrap
{
    public class AppContainer
    {
        private ServiceProvider _serviceProvider;
        private IContainer container;

        public AppContainer()
        {
            // services
            var builder = new ContainerBuilder();

            DotNetifyHubProxy.ServerUrl = "http://localhost:5000";

            _serviceProvider = new ServiceCollection()
               .AddDotNetifyClient()
               .AddSingleton<IUIThreadDispatcher, XamarinUIThreadDispatcher>()
               .AddTransient<TestViewModel>()
               .BuildServiceProvider();

            this.container = builder.Build();
        }


        #region Methods
        /// <summary>
        /// Resolves the desired element.
        /// </summary>
        /// <typeparam name="T">The type of the element.</typeparam>
        /// <returns>Returns the element.</returns>
        public T Resolve<T>() where T : class => container.Resolve<T>();

        /// <summary>
        /// Resolves the desired element.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <returns>Returns the element.</returns>
        public object Resolve(Type type) => container.Resolve(type);

        /// <summary>
        /// Resolves the service.
        /// </summary>
        /// <typeparam name="T">The type of the container.</typeparam>
        /// <returns>Returns the resolved container.</returns>
        public T ResolveService<T>() => _serviceProvider.GetService<T>();
        #endregion
    }
}
