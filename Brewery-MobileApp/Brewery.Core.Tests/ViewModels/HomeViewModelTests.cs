using DTOs = Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;
using Brewery.Core.Services.Interfaces.Business;
using Brewery.Core.ViewModels;
using Moq;

namespace Brewery.Core.Tests.ViewModels;

    [TestClass]
    public class HomeViewModelTests
    {
        private Mock<IBreweryService> _mockBreweryService;
        private HomeViewModel _viewModel;

        [TestInitialize]
        public void Setup()
        {
            _mockBreweryService = new Mock<IBreweryService>();
            _viewModel = new HomeViewModel(_mockBreweryService.Object);
        }

        [TestMethod]
        public void Title_ShouldNotBeNull()
        {
            // Assert
            Assert.IsNotNull(_viewModel.Title);
        }

        [TestMethod]
        public void ShouldLoadData_OnInitialization()
        {
            // Arrange
            var breweries = new List<DTOs.Brewery> { new DTOs.Brewery { Name = "Brewery1" }, new DTOs.Brewery { Name = "Brewery2" } };
            _mockBreweryService.Setup(service => service.GetBreweriesList()).Returns(breweries);

            // Act
            _viewModel = new HomeViewModel(_mockBreweryService.Object);

            // Assert
            Assert.AreEqual(breweries.Count, _viewModel.BreweriesList.Count);
            Assert.AreEqual(breweries.Count, _viewModel.BreweriesFilteredList.Count);
        }

        [TestMethod]
        public void SelectBrewery_ShouldInvoke_ShowBreweryDetail_WhenBrewerySelected()
        {
            // Arrange
            bool eventInvoked = false;
            _viewModel.ShowBreweryDetail += (sender, args) => eventInvoked = true;

            var selectedBrewery = new DTOs.Brewery { Name = "BrewerySelected" };
            _mockBreweryService.Setup(service => service.GetBrewerySelected()).Returns(selectedBrewery);

            // Act
            _viewModel.SelectBrewery(0);

            // Assert
            Assert.IsTrue(eventInvoked);
        }

        [TestMethod]
        public void SelectBrewery_ShouldNotInvoke_ShowBreweryDetail_WhenBreweryNotSelected()
        {
            // Arrange
            bool eventInvoked = false;
            _viewModel.ShowBreweryDetail += (sender, args) => eventInvoked = true;

            _mockBreweryService.Setup(service => service.GetBrewerySelected()).Returns((DTOs.Brewery)null);

            // Act
            _viewModel.SelectBrewery(0);

            // Assert
            Assert.IsFalse(eventInvoked);
        }
    }