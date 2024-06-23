# Documentation for .NET Android and .NET iOS Application for OpenBreweryDB

## 1. Overview

This mobile application is developed **for Android and iOS** platforms <u>using .NET</u>. The application consumes the **OpenBreweryDB API** to <u>list breweries</u> and display detailed information about each brewery. The API endpoint used is https://api.openbrewerydb.org/v1/breweries.

![highlevelworkflow](DocumentationAssets/Breweries_list.png) ![highlevelworkflow](DocumentationAssets/Breweries_detail.png)

## 2. Requirements

### Software Requirements
- Visual Studio with .NET Android and .NET iOS installed (optionally you can use Rider or VS Code)
- .NET 8.0 SDK or higher
- Android SDK
- iOS SDK
- Android Emulator or physical Android device
- iOS Emulator or physical iOS device
- Internet connection

### Hardware Requirements
- macOS operating system

## 3. Installation

### Cloning the Repository

`git clone https://github.com/nunomir45/Brewery-MobileApp`

### Setting Up the Environment
- Open the project in Visual Studio / Rider / VS Code.
- Restore the required NuGet packages.
- Set up the emulators or physical devices for testing.


## 4. Features

- **Brewery Listing:** The application makes a GET request to https://api.openbrewerydb.org/v1/breweries and displays the list of breweries.
- **Brewery Details:** By selecting a brewery, the application displays detailed information about the selected brewery.

## 5. Project structure


Brewery-MobileApp/
│
├── Brewery-MobileApp/
│ ├── <u>Brewery.Core</u>/ # Shared code
│ │ ├── Constants/ # Constants files
│ │ ├── ViewModels/ # Business logic
│ │ └── Services/ # Services (Including API calls)
│ ├── <u>Brewery.Droid</u>/ # Project Android
│ │ ├── Resources/ # Images and layouts
│ │ ├── UI/ # UI logic goes here
│ │ │ ├── Activities/
│ │ │ ├── Adapters/
│ │ │ ├── Fragments/
│ │ │ ├── ViewHolders/ # ViewHolders from Adapters
│ ├── <u>Brewery.iOS</u>/ # Project iOS
│ │ ├── UI/ # UI logic goes here
│ │ │ ├── Cells/ # Cells from UITableViews
│ │ │ ├── ViewController/ #ViewControllers
│
├── DocumentationAssets
├── README.md # Documentation
└── .gitignore


## 6. References

- [.NET Android and .NET iOS](https://dotnet.microsoft.com/en-us/apps/mobile) 
- [OpenBreweryDB API Documentation](https://openbrewerydb.org)