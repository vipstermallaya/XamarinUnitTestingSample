using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;
using Xamarin.Forms;

namespace UnitTestingSample.Helpers
{
    public class NavigationService : INavigationService
    {
        Xamarin.Forms.INavigation _navigation;
        public Task NavigateBack()
        {
            Initialize();
            return _navigation.PopAsync(); 
        }

        public Task NavigateTo(string ViewModelName)
        {
            Initialize();
            var viewName = ViewModelName.Replace("ViewModel", "View");
            var typeInformation = Type.GetType($"{ typeof(CountriesView).Namespace}.{viewName}");
            var viewObject = Activator.CreateInstance(typeInformation) as ContentPage;
            return _navigation.PushAsync(viewObject);
        }
        private void Initialize()
        {
            _navigation = _navigation ?? App.Current.MainPage.Navigation;
        }
    }
}
