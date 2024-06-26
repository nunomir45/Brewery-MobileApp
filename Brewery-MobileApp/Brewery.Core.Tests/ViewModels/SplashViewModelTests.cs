using System;
using System.Threading.Tasks;
using Brewery.Core.Services.Interfaces.Business;
using Brewery.Core.Services.Interfaces.CrossPlatform;
using Brewery.Core.Services.Interfaces.WebService;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices;
using Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;
using Brewery.Core.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Brewery.Core.Tests.ViewModels
{
    [TestClass]
    public class SplashViewModelTests
    {
        private Mock<IListBreweriesRequest> _mockListBreweriesRequest;
        private Mock<IBreweryService> _mockBreweryService;
        private Mock<IDialogService> _mockDialogService;
        private SplashViewModel _viewModel;

        [TestInitialize]
        public void Setup()
        {
            _mockListBreweriesRequest = new Mock<IListBreweriesRequest>();
            _mockBreweryService = new Mock<IBreweryService>();
            _mockDialogService = new Mock<IDialogService>();
            _viewModel = new SplashViewModel(_mockListBreweriesRequest.Object, _mockBreweryService.Object, _mockDialogService.Object);
        }

        [TestMethod]
        public void Title_ShouldNotBeNull()
        {
            // Assert
            Assert.IsNotNull(_viewModel.Title);
        }

        [TestMethod]
        public async Task ShouldCall_LoadBreweries_OnAppearing()
        {
            // Arrange
            _mockBreweryService.Setup(service => service.LoadBreweries()).Returns(Task.CompletedTask as Task<Response<ListBreweriesOutput>>).Verifiable();

            // Act
            _viewModel.Appearing();

            // Assert
            _mockBreweryService.Verify(service => service.LoadBreweries(), Times.Once);
        }
        
        [TestMethod]
        public async Task ShouldInvoke_ShowHome_AfterDelay()
        {
            // Arrange
            _mockBreweryService.Setup(x => x.LoadBreweries())
                .ReturnsAsync(() =>
                {
                    return new Response<ListBreweriesOutput>(true, new ListBreweriesOutput(""), "");
                });

            bool eventWasRaised = false;
            _viewModel.ShowHome += (sender, args) => eventWasRaised = true;

            // Act
            _viewModel.Appearing();
            await Task.Delay(5000);

            // Assert
            Assert.IsTrue(eventWasRaised);
        }
    }
}