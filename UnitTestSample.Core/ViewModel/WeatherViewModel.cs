using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilities;
using Utilities.Framework;
using DryIoc;
using Utilities.Interfaces;
using UnitTestSample.Core.Modal;

namespace UnitTestSample.Core.ViewModel
{
    public class WeatherViewModel : BaseViewModel
    {
        private Dictionary<string, double> tempDictionary;
        private string _CurrentTemparature;
        private string _MaxTemparature;
        private string _MinTemparature; 
        private IWebserviceHandler _webHandler;
        private WeatherObject _weatherObject;
        private string _Location;

        public async Task Initialize()
        {
            _webHandler = IocContianer.IocContainer.Resolve<IWebserviceHandler>();
            var result = await _webHandler.GetWeatherDetails(32.238413, 77.189310);
            _weatherObject = result as WeatherObject;
            CurrentTemparature = $"{_weatherObject.list[0].main.temp.ToString()} Kelvin";
            MaxTemparature = $"{_weatherObject.list[0].main.temp_max.ToString()} Kelvin";
            MinTemparature = $"{_weatherObject.list[0].main.temp_min.ToString()} Kelvin";
            Location = $"{_weatherObject.city.name}, Currently Weather Is {_weatherObject.list[0].weather[0].description}";
            tempDictionary = new Dictionary<string, double>();
            tempDictionary.Add("Temp", _weatherObject.list[0].main.temp);
            tempDictionary.Add("Min_Temp", _weatherObject.list[0].main.temp);
            tempDictionary.Add("Max_Temp", _weatherObject.list[0].main.temp_min); 
        } 
        public string CurrentTemparature
        {
            get
            {
                return _CurrentTemparature;
            }
            set
            {
                _CurrentTemparature = value;
                OnPropertyChanged(nameof(CurrentTemparature));
            }
        } 
        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
                OnPropertyChanged(nameof(Location));
            }
        } 
        public string MaxTemparature
        {
            get
            {
                return _MaxTemparature;
            }
            set
            {
                _MaxTemparature = value;
                OnPropertyChanged(nameof(MaxTemparature));
            }
        }
        public string MinTemparature
        {
            get
            {
                return _MinTemparature;
            }
            set
            {
                _MinTemparature = value;
                OnPropertyChanged(nameof(MinTemparature));
            }
        } 
        public ICommand ChangeToKelvin { get; set; }
        public ICommand ChangeToCelcius { get; set; }
        public ICommand CountryListing { get; set; }

        public WeatherViewModel()
        {
            ChangeToKelvin = new Command(ChangeToKelvinAction);
            ChangeToCelcius = new Command(ChangeToCelciusAction);
            CountryListing = new Command(CountryListingAction);
            Title = "Todays Weather ";
        }

        private void CountryListingAction(object obj)
        {
            this.ViewModelNavigator.NavigateTo(nameof(CountriesViewModel));
        }

        private void ChangeToCelciusAction(object obj)
        {
            CurrentTemparature = $"{ GetCelcius(tempDictionary["Temp"])} Celcius";
            MinTemparature = $"{ GetCelcius(tempDictionary["Min_Temp"])} Celcius"; 
            MaxTemparature = $"{ GetCelcius(tempDictionary["Max_Temp"])} Celcius";
        }

        private void ChangeToKelvinAction(object obj)
        {
            CurrentTemparature = $"{ tempDictionary["Temp"]} Kelvin";
            MinTemparature = $"{tempDictionary["Min_Temp"]} Kelvin";
            MaxTemparature = $"{tempDictionary["Max_Temp"]} Kelvin";
        }

        public double GetCelcius(double TempInKelvin)
        {
            if(TempInKelvin == double.MinValue ||
                TempInKelvin == double.MaxValue || 
                TempInKelvin <= -273d)
            {
                throw new ArgumentOutOfRangeException("Invalid  Value. Not Acceepted");
            }
            return TempInKelvin - 273d; 
        }
    }
}
