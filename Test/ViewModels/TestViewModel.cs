using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using DotNetify.Client;

namespace Test.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly IDotNetifyClient _dotnetify;
        private readonly IDotNetifyHubProxy _hubProxy;

        public string ServerTime { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion INotifyPropertyChanged

        public TestViewModel(IDotNetifyClient dotnetify, IDotNetifyHubProxy hubProxy)
        {
            _dotnetify = dotnetify;
            _hubProxy = hubProxy;

            _ = ConnectAsync();
        }

        public async Task ConnectAsync()
        {
            _hubProxy.StateChanged += async (sender, state) =>
            {
                if (state == HubConnectionState.Disconnected)
                {
                    Dispose();
                    await ConnectAsync();
                }
            };

            // Connect to the server-side view model.
            _dotnetify.ConnectAsync(
                "HelloWorldVM",
                this,
                new VMConnectOptions { VMArg = new { Greetings = "Hello World!" } }
          );
        }

        public void Dispose() => _dotnetify.Dispose();
    }
}
