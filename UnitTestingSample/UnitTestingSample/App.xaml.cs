using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DryIoc;
using Utilities;
using UnitTestingSample.Helpers;
using Utilities.Interfaces;
using UnitTestSample.Core.Helper;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UnitTestingSample
{
    public partial class App : Application
    {
        public App()
        {
            IocContianer.IocContainer.Register<INavigationService, NavigationService>();
            IocContianer.IocContainer.Register<IWebserviceHandler, WebServiceHandler>();

            InitializeComponent();

            MainPage = new NavigationPage(new WeatherView());
            

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
