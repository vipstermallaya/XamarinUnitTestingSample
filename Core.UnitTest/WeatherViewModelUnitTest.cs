using Microsoft.VisualStudio.TestTools.UnitTesting;
using DryIoc;
using Utilities;
using Utilities.Interfaces;
using Core.UnitTest.Data;
using System.Threading.Tasks;
using UnitTestSample.Core.ViewModel;
using System;

namespace Core.UnitTest
{
    [TestClass]
    public class WeatherViewModelUnitTest
    {
        private WeatherViewModel viewModel;

        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {
            try
            {
                var moqWebservice = new Moq.Mock<IWebserviceHandler>();
                moqWebservice.Setup(method => method.GetWeatherDetails(32.238413, 77.189310)).
                    Returns(Task.FromResult<object>(WeatherData.GetWeatherData()));
                IocContianer.IocContainer.UseInstance<IWebserviceHandler>(moqWebservice.Object);

            }
            catch (Exception ex)
            {
            }
        }

        [TestInitialize]
        public void TestSetup()
        {
            viewModel = new WeatherViewModel();
        }

        #region InitializeUnitTest
        [TestMethod]
        [TestCategory("Initialization")]
        public async Task InitializeSuccess()
        { 
            viewModel = new WeatherViewModel();
            await viewModel.Initialize();
            //This is a failure condition.....
            Assert.IsTrue(string.Compare("Manali, Currently Weather Is light snow1", viewModel.Location) == 0, "Invalid Location value populated");
            Assert.IsTrue(string.Compare("252.41 Kelvin", viewModel.CurrentTemparature) == 0, "Invalid Current Temparature value populated");
            Assert.IsTrue(string.Compare("253.681 Kelvin", viewModel.MaxTemparature) == 0, "Invalid Max Temparature value populated");
            Assert.IsTrue(string.Compare("252.41 Kelvin", viewModel.MinTemparature) == 0, "Invalid Min Temparature value populated"); 
        }
        #endregion

        #region Temparature Test       
        [TestMethod]
        //[Ignore] // to ignore a test
        [Description("This test the basic convertion of kelvin to celcius")]
        [TestProperty("TestPass", "Accesibility")]
        [TestCategory("Temparature")] // Use Triat=Temparature
        public void GetCelcius_BasicUnitTest()
        {
            var viewModel = new WeatherViewModel();
            var result = viewModel.GetCelcius(273);
            Assert.AreEqual(result, 0d);
        }


        [TestMethod]
        [DataRow(double.MinValue)]
        [DataRow(double.MaxValue)]
        [DataRow(-274d)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestCategory("Temparature")]
        public void GetCelcius_MinMaxBoundaryValueUnitTest(double value)
        {
            viewModel = new WeatherViewModel();
            //Assert.ThrowsException<ArgumentOutOfRangeException>(() => { viewModel.GetCelcius(value); }); 
            viewModel.GetCelcius(value);
        }
        #endregion

        #region CleanUp
        [TestCleanup]

        public void TestCleanUp()
        {

        }
        [ClassCleanup]
        public static void TestClassCleanUp()
        {
            IocContianer.IocContainer.Dispose();
        }
        #endregion


    }
}
