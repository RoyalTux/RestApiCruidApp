# RestApiCruidApp
Angular 8 App with REST API and ASP.NET Core 2.2

## Prerequisites

- [.NET Core 2.2 SDK](https://dotnet.microsoft.com/download/visual-studio-sdks ".NET Core is a cross-platform version of .NET for building websites, services, and console apps.")
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/ "Code faster. Work smarter. Create the future with the best-in-class IDE.")

*For the Angular front-end we'll also use:*

- [VS Code](https://code.visualstudio.com/ "Code editing. Redefined.")
- [Node.js](https://nodejs.org/en/ "Node.js® is a JavaScript runtime built on Chrome's V8 JavaScript engine.")
- [Angular CLI](https://cli.angular.io/ "A command line interface for Angular.")

If you clone the repository, make sure you setup the database and Entity Framework migrations!
This is how in Visual Studio 2019:

- Remove the contents of the folder Migrations.
- Then open the Package Manager Console (Tools -> Nuget Package Manager -> Package Manager Console).
- Run the following commands:
  - Add-Migration Initial
  - Update-Database
 - Now press F5 and run the application. You will have an empty blog list to start with.
 
## Debugging

If you get an error message running the app, first make sure you installed node modules using the npm install command.
In VS Code or in the Node.js command prompt, run npm install in the ClientApp folder.
