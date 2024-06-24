using Brewery.Core.Services.Implementations.Business;
using DTOs = Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;
using Brewery.Core.Services.Interfaces.Business;
using Brewery.Core.ViewModels;
using Moq;

namespace Brewery.Core.Tests.ViewModels;

[TestClass]
public class BreweryDetailViewModelTests
{
    [TestMethod]
    public void ShouldInitialize_BreweryFields()
    {
        // Arrange
        var breweryServiceMock = new Mock<IBreweryService>();
        var brewerySelected = new DTOs.Brewery { Name = "brewery"};
        breweryServiceMock.Setup(s => s.GetBrewerySelected()).Returns(brewerySelected);

        // Act
        var viewModel = new BreweryDetailViewModel(breweryServiceMock.Object);

        // Assert
        Assert.IsNotNull(viewModel.BreweryFields);
    }
}