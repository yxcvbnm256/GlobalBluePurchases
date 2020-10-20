GlobalBluePurchases
==========
Global Blue .NET developer homework. This API can compute missing tax information about certain purchase. According to the specification:
- API is implemented with .NET Core 3.1
- dependency injection is used for injecting a class that computes the missing information
- NuGet is used for obtaining Swagger package
- even though specification does not say that, negative number inputs are ruled out as it does not make sense to compute tax information with them

# Usage
- API is available at https://globalbluepurchases.azurewebsites.net/
- API documentation is available at https://globalbluepurchases.azurewebsites.net/swagger

# Build
- .NET Core 3.1 SDK and Visual Studio 2019 has to be installed in order to run the API locally via Visual Studio.
- .NET Core 3.1 hosting bundle has to be installed in order to host the API locally via IIS or dotnet
