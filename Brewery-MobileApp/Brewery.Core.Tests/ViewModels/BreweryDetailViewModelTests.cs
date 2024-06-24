using DTOs = Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;
using Brewery.Core.Services.Interfaces.Business;
using Brewery.Core.ViewModels;
using Moq;

namespace Brewery.Core.Tests.ViewModels;

[TestClass]
public class BreweryDetailViewModelTests
{
    private Mock<IBreweryService> _mockBreweryService;
    private BreweryDetailViewModel _viewModel;

    [TestInitialize]
    public void Setup()
    {
        _mockBreweryService = new Mock<IBreweryService>();
        _viewModel = new BreweryDetailViewModel(_mockBreweryService.Object);
    }

    [TestMethod]
    public void BreweryDetailViewModel_ShouldInitialize_BreweryFields()
    {
        // Arrange
        var brewery = new DTOs.Brewery { Name = "Brewery", Address1 = "Portugal" };
        _mockBreweryService.Setup(service => service.GetBrewerySelected()).Returns(brewery);

        // Act
        _viewModel = new BreweryDetailViewModel(_mockBreweryService.Object);

        // Assert
        Assert.IsNotNull(_viewModel.BreweryFields);
        Assert.AreEqual(2, _viewModel.BreweryFields.Count);
        Assert.AreEqual("Brewery", _viewModel.BreweryFields[nameof(DTOs.Brewery.Name)]);
        Assert.AreEqual("Portugal", _viewModel.BreweryFields[nameof(DTOs.Brewery.Address1)]);
    }
}