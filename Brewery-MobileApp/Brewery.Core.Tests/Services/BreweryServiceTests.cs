using Brewery.Core.Services.Implementations.Business;
using Moq;
using DTOs = Brewery.Core.Services.Interfaces.WebService.BreweryWebServices.DTOs;

namespace Brewery.Core.Tests.Services;

[TestClass]
public class BreweryServiceTests
{
    private BreweryService _breweryService;

    [TestInitialize]
    public void Setup()
    {
        _breweryService = new BreweryService();
    }
    
    [TestMethod]
    public void SelectBrewery_ShouldSetSelectedBrewery()
    {
        // Arrange
        _breweryService.LoadBreweries().GetAwaiter().GetResult();
        _breweryService.SelectBrewery(0);

        // Act
        var selectedBrewery = _breweryService.GetBrewerySelected();

        // Assert
        Assert.IsNotNull(selectedBrewery);
    }

    [TestMethod]
    public void GetBreweriesList_ShouldReturnBreweriesList()
    {
        // Arrange
        _breweryService.LoadBreweries().GetAwaiter().GetResult();

        // Act
        var breweriesList = _breweryService.GetBreweriesList();

        // Assert
        Assert.IsNotNull(breweriesList);
    }

    [TestMethod]
    public void GetBrewerySelected_ShouldReturnSelectedBrewery()
    {
        // Arrange
        var brewery = new DTOs.Brewery { Name = "Brewery1" };
        typeof(BreweryService).GetField("_brewerySelected", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(_breweryService, brewery);

        // Act
        var selectedBrewery = _breweryService.GetBrewerySelected();

        // Assert
        Assert.IsNotNull(selectedBrewery);
        Assert.AreEqual("Brewery1", selectedBrewery.Name);
    }
}