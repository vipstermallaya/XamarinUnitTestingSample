using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestSample.Core.ViewModel;
using Utilities.Framework;
using Xamarin.Forms;

namespace UnitTestingSample
{
    public partial class WeatherView : ContentPage
    {   
        public WeatherView()
        {
            InitializeComponent();
            var bindingContext = this.BindingContext as WeatherViewModel;
            bindingContext.Initialize();
        }
         



    }
}
