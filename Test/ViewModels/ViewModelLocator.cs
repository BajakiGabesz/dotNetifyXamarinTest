using System;
using Test.Bootstrap;
using Xamarin.Forms.Internals;

namespace Test.ViewModels
{
    [Preserve(AllMembers = true)]
    public static class ViewModelLocator
    {
        #region Fields
        public static readonly AppContainer Container;
        #endregion

        #region Constructors and finalizers
        /// <summary>
        /// Instantiate a <see cref="ViewModelLocator"/>.
        /// </summary>
        static ViewModelLocator()
        {
            Container = new AppContainer();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resolves the container.
        /// </summary>
        /// <typeparam name="T">The type of the container.</typeparam>
        /// <returns>Returns the resolved container.</returns>
        public static T Resolve<T>() where T : class => Container.Resolve<T>();

        /// <summary>
        /// Resolves the service.
        /// </summary>
        /// <typeparam name="T">The type of the container.</typeparam>
        /// <returns>Returns the resolved container.</returns>
        public static T ResolveService<T>() where T : class => Container.ResolveService<T>();
        #endregion
    }
}
