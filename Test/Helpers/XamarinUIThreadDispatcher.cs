using System;
using System.Threading.Tasks;
using DotNetify.Client;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;

namespace Test.Helpers
{
    [Preserve(AllMembers = true)]
    public class XamarinUIThreadDispatcher : IUIThreadDispatcher
    {
        /// <summary>
        /// Invokes an action on the UI thread.
        /// </summary>
        /// <param name="action">The action to invoke.</param>
        public async Task InvokeAsync(Action action)
        {
            if (!MainThread.IsMainThread)
            {
                await MainThread.InvokeOnMainThreadAsync(action);
            }
            else
            {
                action?.Invoke();
            }

            await Task.CompletedTask;
        }
    }
}
