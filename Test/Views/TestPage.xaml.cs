using System;
using Test.ViewModels;
using Xamarin.Forms;

namespace Test.Views
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.ResolveService<TestViewModel>();
            Disappearing += (sender, e) => (BindingContext as IDisposable)?.Dispose();
        }
    }
}
